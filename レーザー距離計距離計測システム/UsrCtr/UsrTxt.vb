'*******************************************************************************
' @(h)  UsrTxt.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrTxt                             System.Windows.Forms.TextBoxを継承
'       初期設定される作成プロパティー
'       pCharType = Me.EnmCharType.All
'       pAutoFocus = True
'       pAutoSelect = True
'       pCondition = EnmCondition.Nomal
'       上記以外は初期の型の値になります。
'
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************
Option Explicit On 
Public Class UsrTxt
    Inherits System.Windows.Forms.TextBox

    Public Enum EnmCharType
        Numonly     '数字のみ
        Letter      '文字のみ
        NumLetter   '文字＆数字
        All         '入力制限なし
        WildNumonly     '数字のみ + *
        WildLetter      '文字のみ + *
        WildNumLetter   '文字＆数字 + *
    End Enum

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
    Private mStrClearText As String
    Private mMaxByte As Integer
    Private mFromToSearch As EnmFromTo
    Private mBlnAutoFocus As Boolean
    Private mBlnAutoSelect As Boolean
    Private mBlnPaste As Boolean
    Private mCharType As EnmCharType
    Private mCondition As EnmCondition
    Private mHissuColor As New System.Drawing.Color
    Private mImpactColor As New System.Drawing.Color
    Private mObjFrom As New Object
    Private mBlnClear As Boolean

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.mStrClearText = ""
        Me.mStrErrText = ""
        Me.mStrFromToErrText = ""
        Me.mBlnAutoFocus = True
        Me.mBlnAutoSelect = True
        Me.mCharType = UsrTxt.EnmCharType.All
        Me.mCondition = EnmCondition.Nomal
        Me.mFromToSearch = EnmFromTo.None
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.mImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
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
        '
        'UsrTxt
        '

    End Sub

#End Region

    ''プロパティー-------------------------------------------------------------------
#Region "pMaxByte"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pMaxByte
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力できるバイト数(0は無制限)
    ' 備　考　：MaxLengthプロパティーは文字数の制限になるので使用しないで下さい。
    '---------------------------------------------------------------------------
#End Region
    Public Property pMaxByte() As Integer
        Get
            pMaxByte = Me.mMaxByte
        End Get
        Set(ByVal Value As Integer)
            Me.mMaxByte = Value
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

#Region "pCharTypeプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pCharTypeプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力文字制限
    ' 備　考　：EnmCharTypeを参照
    '---------------------------------------------------------------------------
#End Region
    Public Property pCharType() As EnmCharType
        Get
            pCharType = Me.mCharType
        End Get
        Set(ByVal Value As EnmCharType)
            Me.mCharType = Value
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
#Region "KeyPress"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：KeyPress
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力文字をChrTypeにより制限します
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrTxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim intByte As Integer
        Dim intMoji As Integer

        ''Maxlength
        If Me.pMaxByte > 0 Then
            intByte = System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.Text)
            intMoji = Me.pMaxByte - intByte
            If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(e.KeyChar) = 2 Then
                If intMoji = 1 Then
                    Me.MaxLength = Me.TextLength
                Else
                    Me.MaxLength = Me.TextLength + intMoji
                End If
            Else
                Me.MaxLength = Me.TextLength + intMoji
            End If
        End If

        '数字
        If Char.IsDigit(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All, UsrTxt.EnmCharType.Numonly, EnmCharType.NumLetter, EnmCharType.WildNumonly, EnmCharType.WildNumLetter

                Case Else
                    e.Handled = True
            End Select

            'backspace,enter
        ElseIf Char.IsControl(e.KeyChar) Then

            'アルファベット
        ElseIf Char.IsLetter(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All, UsrTxt.EnmCharType.Letter, EnmCharType.NumLetter, EnmCharType.WildLetter, EnmCharType.WildNumLetter

                Case Else
                    e.Handled = True
            End Select

            '区切り文字
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All

                Case EnmCharType.WildLetter, EnmCharType.WildNumLetter, EnmCharType.WildNumonly
                    If e.KeyChar = "*" Then

                    Else
                        e.Handled = True
                    End If
                Case Else
                    e.Handled = True
            End Select

            'サロゲート文字
        ElseIf Char.IsSurrogate(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All

                Case Else
                    e.Handled = True
            End Select

            'シンボル
        ElseIf Char.IsSymbol(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All

                Case Else
                    e.Handled = True
            End Select

            'スペース
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All

                Case Else
                    e.Handled = True
            End Select

        Else

        End If
    End Sub

#Region "TextChanged"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：TextChanged
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：最大桁数でタブキーの動作
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrTxt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        Dim i As Integer
        Dim intLength As Integer
        Dim strBuff As String
        Dim strBuff2 As String
        Dim strBuff3 As String

        If Me.mBlnPaste Then
            strBuff = ""
            strBuff2 = ""
            strBuff3 = ""
            ''貼付で許可のない文字を削除(全角)
            Select Case Me.pCharType
                Case EnmCharType.Letter, EnmCharType.Numonly, EnmCharType.NumLetter, EnmCharType.WildLetter, EnmCharType.WildNumonly, EnmCharType.WildNumLetter
                    For i = 0 To Me.TextLength - 1
                        If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.Text.Chars(i)) = 1 Then
                            strBuff = strBuff & Me.Text.Chars(i)
                        End If
                    Next
                Case Else
                    strBuff = Me.Text
            End Select

            ''貼付で許可のない文字を削除(数値文字)
            If Me.pCharType <> EnmCharType.All Then
                For i = 0 To strBuff.Length - 1
                    Select Case True
                        ''数値
                    'Case strBuff.Chars(i).IsDigit(strBuff.Chars(i))
                     Case Char.IsDigit(strBuff.Chars(i))
                            Select Case Me.pCharType
                                Case EnmCharType.Numonly, EnmCharType.NumLetter, EnmCharType.WildNumonly, EnmCharType.WildNumLetter
                                    strBuff2 = strBuff2 & strBuff.Chars(i)
                                Case Else

                            End Select
                            ''文字
                        Case Char.IsLetter(strBuff.Chars(i))
                            Select Case Me.pCharType
                                Case EnmCharType.Letter, EnmCharType.NumLetter, EnmCharType.WildLetter, EnmCharType.WildNumLetter
                                    strBuff2 = strBuff2 & strBuff.Chars(i)
                                Case Else

                            End Select
                            ''*
                        Case strBuff.Chars(i) = "*"
                            Select Case Me.pCharType
                                Case EnmCharType.WildNumonly, EnmCharType.WildLetter, EnmCharType.WildNumLetter
                                    strBuff2 = strBuff2 & strBuff.Chars(i)
                                Case Else

                            End Select
                        Case Else

                    End Select
                Next
            Else
                strBuff2 = strBuff
            End If

            ''貼付で制限を越えている場合
            If Me.pMaxByte > 0 Then
                For i = 0 To strBuff2.Length - 1
                    intLength = intLength + System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(strBuff2.Chars(i))
                    If intLength <= Me.pMaxByte Then
                        strBuff3 = strBuff3 & strBuff2.Chars(i)
                    ElseIf intLength > Me.pMaxByte Then
                        Exit For
                    End If
                Next
            Else
                strBuff3 = strBuff2
            End If

            If Me.Text <> strBuff3 Then
                Me.Text = strBuff3
            End If
            Me.mBlnPaste = False
        End If

        If Me.mBlnAutoFocus = True Then
            If Me.pMaxByte > 0 And _
               Me.pMaxByte <= System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.Text) And _
               Me.SelectionStart = CType(sender, TextBox).TextLength Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

#Region "Enter"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Enter
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォーカス取得時に数値入力時は「,」をとる、文字選択
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrTxt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        ''文字選択
        If Me.mBlnAutoSelect Then
            Me.SelectAll()
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_PASTE As Integer = &H302

        Select Case m.Msg
            Case WM_PASTE   ''貼り付けメッセージ
                Me.mBlnPaste = True
                MyBase.WndProc(m)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

End Class
