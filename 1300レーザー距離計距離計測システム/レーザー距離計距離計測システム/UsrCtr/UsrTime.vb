'*******************************************************************************
' @(h)  UsrLocation.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrLocation                             System.Windows.Forms.UserControlを継承
'       初期設定される作成プロパティー
'       pCondition = EnmCondition.Nomal
'       上記以外は初期の型の値になります。
'
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************
Option Explicit On 
Public Class UsrTime
    Inherits System.Windows.Forms.UserControl

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
        Me.mStrFromToErrText = ""
        Me.mStrClearText = ""
        Me.mStrErrText = ""
        Me.mCondition = EnmCondition.Nomal
        Me.mFromToSearch = EnmFromTo.None
        Me.Size = New System.Drawing.Size(58, 22)
        Me.mHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.mImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.pIsClear = True
    End Sub

    ' UserControl1 は dispose をオーバーライドしてコンポーネント一覧を消去します。
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtMin As System.Windows.Forms.TextBox
    Friend WithEvents txtHour As System.Windows.Forms.TextBox
    Friend WithEvents lblSura As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblSura = New System.Windows.Forms.Label
        Me.txtMin = New System.Windows.Forms.TextBox
        Me.txtHour = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSura
        '
        Me.lblSura.AutoSize = True
        Me.lblSura.BackColor = System.Drawing.SystemColors.Window
        Me.lblSura.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSura.Location = New System.Drawing.Point(20, 1)
        Me.lblSura.Name = "lblSura"
        Me.lblSura.Size = New System.Drawing.Size(13, 18)
        Me.lblSura.TabIndex = 10
        Me.lblSura.Text = "："
        Me.lblSura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMin
        '
        Me.txtMin.AutoSize = False
        Me.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMin.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMin.Location = New System.Drawing.Point(36, 1)
        Me.txtMin.MaxLength = 2
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(16, 16)
        Me.txtMin.TabIndex = 2
        Me.txtMin.Text = ""
        '
        'txtHour
        '
        Me.txtHour.AutoSize = False
        Me.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHour.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtHour.Location = New System.Drawing.Point(4, 1)
        Me.txtHour.MaxLength = 2
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Size = New System.Drawing.Size(16, 16)
        Me.txtHour.TabIndex = 1
        Me.txtHour.Text = ""
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtHour)
        Me.Panel1.Controls.Add(Me.lblSura)
        Me.Panel1.Controls.Add(Me.txtMin)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(58, 22)
        Me.Panel1.TabIndex = 13
        '
        'UsrTime
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.Panel1)
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Name = "UsrTime"
        Me.Size = New System.Drawing.Size(58, 22)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ''プロパティー-------------------------------------------------------------------
#Region "TEXTプロパティー(オーバーライド)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：TEXTプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：時間を : ありで取得する。
    ' 備　考　：セットする場合は : なしでも可
    '---------------------------------------------------------------------------
#End Region
    Public Overrides Property Text() As String
        Get
            Text = Me.txtHour.Text & Me.txtMin.Text
        End Get
        Set(ByVal Value As String)
            Dim strBuff As String

            strBuff = Replace(Value, ":", "")
            If strBuff Is Nothing Then
                Me.txtHour.Text = ""
                Me.txtMin.Text = ""
            ElseIf strBuff.Length = 4 Then
                Me.txtHour.Text = strBuff.Substring(0, 2)
                Me.txtMin.Text = strBuff.Substring(2, 2)
            Else
                Me.txtHour.Text = ""
                Me.txtMin.Text = ""
            End If
        End Set
    End Property

#Region "pTextUserプロパティー(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pTextUserプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：時間形式でのText
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pTextUser() As String
        Get
            pTextUser = Me.txtHour.Text & ":" & Me.txtMin.Text
        End Get
    End Property

#Region "pIsTimeプロパティー(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pIsDateプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：時間として正しいか
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pIsTime() As Boolean
        Get
            If Me.Text.Length > 0 Then
                If Me.txtHour.Text.Length <> 2 Then

                ElseIf Me.txtMin.Text.Length <> 2 Then

                ElseIf CInt(Me.txtHour.Text) >= 24 Then

                ElseIf CInt(Me.txtMin.Text) >= 60 Then

                Else
                    Return True
                End If
            Else
                Return True
            End If
        End Get
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
    ' 機能説明：初期表示するtextプロパティーの取得設定
    ' 備　考　：ドロップダウン形式時の初期表示する。テキストの取得設定
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

#Region "pHourプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pHourプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：時間を取得設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pHour() As String
        Get
            pHour = Me.txtHour.Text
        End Get
        Set(ByVal Value As String)
            Me.txtHour.Text = Value
        End Set
    End Property

#Region "pMinプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pMinプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：分を取得設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pMin() As String
        Get
            pMin = Me.txtMin.Text
        End Get
        Set(ByVal Value As String)
            Me.txtMin.Text = Value
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
    ' 機能説明：数値のみ入力可
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMin.KeyPress, txtHour.KeyPress
        '数字
        If Char.IsDigit(e.KeyChar.ToString.Chars(0)) = True Then

            'backspace,enter
        ElseIf Char.IsControl(e.KeyChar.ToString.Chars(0)) = True Then

            'アルファベット
        ElseIf Char.IsLetter(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            '区切り文字
        ElseIf Char.IsPunctuation(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            'サロゲート文字
        ElseIf Char.IsSurrogate(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            'シンボル
        ElseIf Char.IsSymbol(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            'スペース
        ElseIf Char.IsWhiteSpace(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

        Else
        End If

    End Sub

#Region "Enter"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Enter
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：TEXTを選択状態にする。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMin.Enter, txtHour.Enter
        CType(sender, TextBox).SelectAll()
    End Sub

#Region "TextChanged"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：TextChanged
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：最大桁入力で次の入力へ移動する.
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMin.TextChanged, txtHour.TextChanged
        ''ユーザーコントロールのテキストチェンジイベントを発生させる
        Call Me.OnTextChanged(e)

        If CType(sender, TextBox).MaxLength > 0 And _
           CType(sender, TextBox).MaxLength <= CType(sender, TextBox).Text.Length And _
           CType(sender, TextBox).SelectionStart = CType(sender, TextBox).Text.Length Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

#Region "BackColorChanged"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：BackColorChanged
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：色変更で内部のコントロールの色を変更する。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrDate_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.BackColorChanged
        Me.txtHour.BackColor = Me.BackColor
        Me.txtMin.BackColor = Me.BackColor
        Me.lblSura.BackColor = Me.BackColor
    End Sub

#Region "SizeChanged"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：SizeChanged
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：サイズを固定する。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrDate_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Size = New System.Drawing.Size(58, 22)
    End Sub

#Region "Leave"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Leave
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力がある場合は０詰する。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub txtHour_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHour.Leave, MyBase.Leave
        If Me.txtHour.TextLength > 0 Then
            If Me.txtHour.TextLength < 2 Then
                Me.txtHour.Text = Me.txtHour.Text.PadLeft(2, Chr(Asc("0")))
            End If
        End If
    End Sub

#Region "Leave"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Leave
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力がある場合は０詰する。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub txtMin_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMin.Leave, MyBase.Leave
        If Me.txtMin.TextLength > 0 Then
            If Me.txtMin.TextLength < 2 Then
                Me.txtMin.Text = Me.txtMin.Text.PadLeft(2, Chr(Asc("0")))
            End If
        End If
    End Sub

    ''メソッド-------------------------------------------------------------------
#Region "gSubFocus"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubFocus
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：時間にフォーカースをセット。
    ' 備　考　：このコントロールにフォーカスをセットする場合はこのメソッドを使ってください
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubFocus()
        Me.txtHour.Focus()
    End Sub

End Class
