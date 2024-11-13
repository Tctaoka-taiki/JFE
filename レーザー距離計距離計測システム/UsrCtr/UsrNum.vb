'*******************************************************************************
' @(h)  UsrNum.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrNum                           System.Windows.Forms.NumericUpDownを継承
'       初期設定される作成プロパティー
'       pCondition = EnmCondition.Nomal
'       pClearText = "0"
'       pAutoFocus = True
'       pAutoSelect = True
'       上記以外は初期の型の値になります。
'
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ThousandsSeparator = True
'       ImeMode = ImeMode.Disable
'       TextAlign = HorizontalAlignment.Right
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************
Option Explicit On 
Public Class UsrNum
    Inherits System.Windows.Forms.NumericUpDown

    Public Enum EnmCondition
        Nomal       '入力許可
        Fuka        '入力不可
        Hissu       '必須入力
        Impact      '強調(目立つ色を使用する)
    End Enum

    Public Enum EnmFromTo
        None    ''なし
        Num     ''数値
        Letter  ''文字
    End Enum

    Private mStrErrText As String
    Private mStrFromToErrText As String
    Private mFromToSearch As EnmFromTo
    Private mBlnAutoFocus As Boolean
    Private mBlnAutoSelect As Boolean
    Private mCondition As EnmCondition
    Private mHissuColor As New System.Drawing.Color
    Private mImpactColor As New System.Drawing.Color
    Private mObjFrom As New Object
    Private mBlnClear As Boolean
    Private mStrClearText As String = ""

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.mStrErrText = ""
        Me.mStrFromToErrText = ""
        Me.mStrClearText = "0"
        Me.mBlnAutoFocus = True
        Me.mBlnAutoSelect = True
        Me.ThousandsSeparator = True
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.mImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.mCondition = EnmCondition.Nomal
        Me.mFromToSearch = EnmFromTo.None
        Me.ImeMode = Windows.Forms.ImeMode.Disable
        Me.TextAlign = HorizontalAlignment.Right
        Me.pIsClear = True
    End Sub

    'UserControl はコンポーネント一覧を消去するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    ' Windows フォーム デザイナを使って変更してください。  
    ' コード エディタは使用しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    ''プロパティー-------------------------------------------------------------------
#Region "pIsClearプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pIsClearプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：初期化するときににTextプロパティーを初期化するかどうか
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pIsClear() As Boolean
        Get
            pIsClear = Me.mBlnClear
        End Get
        Set(ByVal Value As Boolean)
            Me.mBlnClear = Value
        End Set
    End Property

#Region "pClearTextプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pClearTextプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：初期表示するtext
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pClearText() As String
        Get
            pClearText = mStrClearText
        End Get
        Set(ByVal Value As String)
            mStrClearText = Value
        End Set
    End Property

#Region "pAutoFocusプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pAutoFocusプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：最大桁数入力時に次のコントロールに移動するか
    ' 備　考　：TRUE=移動する、FALSE=移動しない
    '---------------------------------------------------------------------------
#End Region
    Public Property pAutoFocus() As Boolean
        Get
            pAutoFocus = Me.mBlnAutoFocus
        End Get
        Set(ByVal Value As Boolean)
            Me.mBlnAutoFocus = Value
        End Set
    End Property

#Region "pAutoSelectプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pAutoSelectプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォーカス取得時に文字選択するか
    ' 備　考　：TRUE=選択する、FALSE=選択しない
    '---------------------------------------------------------------------------
#End Region
    Public Property pAutoSelect() As Boolean
        Get
            pAutoSelect = Me.mBlnAutoSelect
        End Get
        Set(ByVal Value As Boolean)
            Me.mBlnAutoSelect = Value
        End Set
    End Property

#Region "pConditionプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pConditionプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力状態,背景色変更
    ' 備　考　：EnmConditionを参照
    '---------------------------------------------------------------------------
#End Region
    Public Property pCondition() As EnmCondition
        Get
            pCondition = mCondition
        End Get
        Set(ByVal Value As EnmCondition)
            mCondition = Value
            Select Case Me.mCondition
                Case EnmCondition.Nomal
                    Me.Enabled = True
                    Me.BackColor = System.Drawing.SystemColors.Window
                Case EnmCondition.Fuka
                    Me.Enabled = False
                    Me.BackColor = System.Drawing.SystemColors.Control
                Case EnmCondition.Hissu
                    Me.Enabled = True
                    Me.BackColor = mHissuColor
                Case EnmCondition.Impact
                    Me.Enabled = True
                    Me.BackColor = mImpactColor

            End Select
        End Set
    End Property

#Region "pErrTextプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pErrTextプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力エラー時に表示される
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pErrText() As String
        Get
            pErrText = mStrErrText
        End Get
        Set(ByVal Value As String)
            mStrErrText = Value
        End Set
    End Property

#Region "pFromToSearchプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pFromToSearchプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：FromToのEnmFromToで行う
    ' 備　考　：pFromObjに割り付けたコントロールとの範囲検索を行う
    '---------------------------------------------------------------------------
#End Region
    Public Property pFromToSearch() As EnmFromTo
        Get
            pFromToSearch = mFromToSearch
        End Get
        Set(ByVal Value As EnmFromTo)
            mFromToSearch = Value
        End Set
    End Property

#Region "pFromObjプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pFromObjプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：FromToの検索を行うか時のFromオブジェクト
    ' 備　考　：同じ型のコントロールでの範囲検索をします。
    '---------------------------------------------------------------------------
#End Region
    Public Property pFromObj() As Object
        Get
            pFromObj = mObjFrom
        End Get
        Set(ByVal Value As Object)
            mObjFrom = Value
        End Set
    End Property

#Region "pFromToErrTextプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pFromToErrTextプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：FromTo範囲入力エラー時に表示される
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pFromToErrText() As String
        Get
            pFromToErrText = mStrFromToErrText
        End Get
        Set(ByVal Value As String)
            mStrFromToErrText = Value
        End Set
    End Property

    ''イベント-------------------------------------------------------------------
#Region "Enter"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Enter
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォーカス取得時に文字選択
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrNum_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        ''カンマ区切り無
        Me.ThousandsSeparator = False

        ''文字選択
        If Me.mBlnAutoSelect Then
            If Me.Text.Length > 0 Then
                Me.Select(0, Me.Text.Length)
            End If
        End If
    End Sub

#Region "Leave"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Leave
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォーカス消失時に数値検証
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrNum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        ''カンマ区切り有り
        Me.ThousandsSeparator = True

        If Not IsNumeric(Me.Text) Then
            Me.Text = Me.mStrClearText
        Else
            Me.ParseEditText()
        End If
    End Sub

    Private Sub UsrNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        If Not IsNumeric(Me.Text) Then
            Me.Text = Me.mStrClearText
            Me.Select(0, Me.Text.Length)
        Else
            If CInt(Me.Text) > Me.Maximum Then
                Me.Text = CStr(Me.Maximum).Replace(",", "")
            ElseIf CInt(Me.Text) < Me.Minimum Then
                Me.Text = CStr(Me.Minimum).Replace(",", "")
            Else

            End If
        End If
    End Sub

End Class
