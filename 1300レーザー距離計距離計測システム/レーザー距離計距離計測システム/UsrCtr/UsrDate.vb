'*******************************************************************************
' @(h)  UsrDate.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrDate                             System.Windows.Forms.UserControlを継承
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
Public Class UsrDate
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
    Private mBlnUnyoubi As Boolean
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
        Me.mCondition = EnmCondition.Nomal
        Me.mFromToSearch = EnmFromTo.None
        Me.Size = New System.Drawing.Size(96, 22)
        Me.mHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.mImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.mStrClearText = ""
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
    Friend WithEvents lblSura2 As System.Windows.Forms.Label
    Friend WithEvents lblSura1 As System.Windows.Forms.Label
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblSura2 = New System.Windows.Forms.Label
        Me.lblSura1 = New System.Windows.Forms.Label
        Me.txtDay = New System.Windows.Forms.TextBox
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSura2
        '
        Me.lblSura2.BackColor = System.Drawing.SystemColors.Window
        Me.lblSura2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSura2.Location = New System.Drawing.Point(63, 1)
        Me.lblSura2.Name = "lblSura2"
        Me.lblSura2.Size = New System.Drawing.Size(12, 16)
        Me.lblSura2.TabIndex = 10
        Me.lblSura2.Text = "/"
        '
        'lblSura1
        '
        Me.lblSura1.BackColor = System.Drawing.SystemColors.Window
        Me.lblSura1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSura1.Location = New System.Drawing.Point(35, 1)
        Me.lblSura1.Name = "lblSura1"
        Me.lblSura1.Size = New System.Drawing.Size(12, 16)
        Me.lblSura1.TabIndex = 9
        Me.lblSura1.Text = "/"
        '
        'txtDay
        '
        Me.txtDay.AutoSize = False
        Me.txtDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDay.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDay.Location = New System.Drawing.Point(75, 1)
        Me.txtDay.MaxLength = 2
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(16, 16)
        Me.txtDay.TabIndex = 2
        Me.txtDay.Text = ""
        '
        'txtMonth
        '
        Me.txtMonth.AutoSize = False
        Me.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMonth.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(47, 1)
        Me.txtMonth.MaxLength = 2
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(16, 16)
        Me.txtMonth.TabIndex = 1
        Me.txtMonth.Text = ""
        '
        'txtYear
        '
        Me.txtYear.AutoSize = False
        Me.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtYear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtYear.Location = New System.Drawing.Point(3, 1)
        Me.txtYear.MaxLength = 4
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(32, 16)
        Me.txtYear.TabIndex = 0
        Me.txtYear.Text = ""
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtYear)
        Me.Panel1.Controls.Add(Me.txtMonth)
        Me.Panel1.Controls.Add(Me.lblSura2)
        Me.Panel1.Controls.Add(Me.lblSura1)
        Me.Panel1.Controls.Add(Me.txtDay)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(96, 22)
        Me.Panel1.TabIndex = 13
        '
        'UsrDate
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.Panel1)
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Name = "UsrDate"
        Me.Size = New System.Drawing.Size(96, 22)
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
    ' 機能説明：日付を / なしで取得する。
    ' 備　考　：セットする場合は / ありでも可
    '---------------------------------------------------------------------------
#End Region
    Public Overrides Property Text() As String
        Get
            Text = Me.txtYear.Text & Me.txtMonth.Text & Me.txtDay.Text
        End Get
        Set(ByVal Value As String)
            Dim strBuff As String

            strBuff = Replace(Value, "/", "")
            If strBuff Is Nothing Then
                Me.txtYear.Text = ""
                Me.txtMonth.Text = ""
                Me.txtDay.Text = ""
            ElseIf strBuff.Length = 8 Then
                Me.txtYear.Text = strBuff.Substring(0, 4)
                Me.txtMonth.Text = strBuff.Substring(4, 2)
                Me.txtDay.Text = strBuff.Substring(6, 2)
            Else
                Me.txtYear.Text = ""
                Me.txtMonth.Text = ""
                Me.txtDay.Text = ""
            End If
        End Set
    End Property

#Region "pTextUserプロパティー(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pTextUserプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：日付形式でのText
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pTextUser() As String
        Get
            pTextUser = Me.txtYear.Text & "/" & Me.txtMonth.Text & "/" & Me.txtDay.Text
        End Get
    End Property

#Region "pIsDateプロパティー(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pIsDateプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：日付として正しいか
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pIsDate() As Boolean
        Get
            If Me.Text.Trim = "" Then
                Return True
            ElseIf Me.txtYear.Text = "" Then
                pIsDate = False
            Else
                pIsDate = IsDate(Me.txtYear.Text & "/" & Me.txtMonth.Text & "/" & Me.txtDay.Text)
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

#Region "pClearUnyoubiプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pClearUnyoubiプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：初期化実行したときに運用日をセットするか
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pClearUnyoubi() As Boolean
        Get
            pClearUnyoubi = Me.mBlnUnyoubi
        End Get
        Set(ByVal Value As Boolean)
            Me.mBlnUnyoubi = Value
        End Set
    End Property

#Region "pYearプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pYearプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：年を取得設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pYear() As String
        Get
            pYear = Me.txtYear.Text
        End Get
        Set(ByVal Value As String)
            Me.txtYear.Text = Value
        End Set
    End Property

#Region "pMonthプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pMonthプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：月を取得設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pMonth() As String
        Get
            pMonth = Me.txtMonth.Text
        End Get
        Set(ByVal Value As String)
            Me.txtMonth.Text = Value
        End Set
    End Property

#Region "pDayプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pDayプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：日を取得設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pDay() As String
        Get
            pDay = Me.txtDay.Text
        End Get
        Set(ByVal Value As String)
            Me.txtDay.Text = Value
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
    Private Sub UsrDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYear.KeyPress, txtMonth.KeyPress, txtDay.KeyPress
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
    Private Sub UsrDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.Enter, txtMonth.Enter, txtDay.Enter
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
    Private Sub UsrDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.TextChanged, txtMonth.TextChanged, txtDay.TextChanged
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
        Me.txtYear.BackColor = Me.BackColor
        Me.txtMonth.BackColor = Me.BackColor
        Me.txtDay.BackColor = Me.BackColor
        Me.lblSura1.BackColor = Me.BackColor
        Me.lblSura2.BackColor = Me.BackColor
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
        Me.Size = New System.Drawing.Size(96, 22)
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
    Private Sub txtYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.Leave, MyBase.Leave
        If Me.txtYear.TextLength > 0 Then
            If Me.txtYear.TextLength < 4 Then
                Me.txtYear.Text = Me.txtYear.Text.PadLeft(4, Chr(Asc("0")))
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
    Private Sub txtMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonth.Leave, MyBase.Leave
        If Me.txtMonth.TextLength > 0 Then
            If Me.txtMonth.TextLength < 2 Then
                Me.txtMonth.Text = Me.txtMonth.Text.PadLeft(2, Chr(Asc("0")))
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
    Private Sub txtDay_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDay.Leave, MyBase.Leave
        If Me.txtDay.TextLength > 0 Then
            If Me.txtDay.TextLength < 2 Then
                Me.txtDay.Text = Me.txtDay.Text.PadLeft(2, Chr(Asc("0")))
            End If
        End If
    End Sub

    'メソッド-------------------------------------------------------------------
#Region "gSubFocus"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubFocus
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：年にフォーカースをセット。
    ' 備　考　：このコントロールにフォーカスをセットする場合はこのメソッドを使ってください
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubFocus()
        Me.txtYear.Focus()
    End Sub

End Class
