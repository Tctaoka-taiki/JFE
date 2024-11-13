'*******************************************************************************
' @(h)  UsrDate.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrDate                             System.Windows.Forms.UserControl���p��
'       �����ݒ肳���쐬�v���p�e�B�[
'       pCondition = EnmCondition.Nomal
'       ��L�ȊO�͏����̌^�̒l�ɂȂ�܂��B
'
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************
Option Explicit On 
Public Class UsrDate
    Inherits System.Windows.Forms.UserControl

    Public Enum EnmCondition
        Nomal       '���͋���
        Fuka        '���͕s��
        Hissu       '�K�{����
        Impact      '����(�ڗ��F���g�p����)
    End Enum

    Public Enum EnmFromTo
        None    ''�Ȃ�
        Num     ''���l
        Letter  ''����
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

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
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

    ' UserControl1 �� dispose ���I�[�o�[���C�h���ăR���|�[�l���g�ꗗ���������܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    ' Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^�͎g�p���Ȃ��ł��������B
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
        Me.lblSura2.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSura2.Location = New System.Drawing.Point(63, 1)
        Me.lblSura2.Name = "lblSura2"
        Me.lblSura2.Size = New System.Drawing.Size(12, 16)
        Me.lblSura2.TabIndex = 10
        Me.lblSura2.Text = "/"
        '
        'lblSura1
        '
        Me.lblSura1.BackColor = System.Drawing.SystemColors.Window
        Me.lblSura1.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.txtDay.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.txtMonth.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.txtYear.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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

    ''�v���p�e�B�[-------------------------------------------------------------------
#Region "TEXT�v���p�e�B�[(�I�[�o�[���C�h)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FTEXT�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���t�� / �Ȃ��Ŏ擾����B
    ' ���@�l�@�F�Z�b�g����ꍇ�� / ����ł���
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

#Region "pTextUser�v���p�e�B�[(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpTextUser�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���t�`���ł�Text
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pTextUser() As String
        Get
            pTextUser = Me.txtYear.Text & "/" & Me.txtMonth.Text & "/" & Me.txtDay.Text
        End Get
    End Property

#Region "pIsDate�v���p�e�B�[(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpIsDate�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���t�Ƃ��Đ�������
    ' ���@�l�@�F
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

#Region "pIsClear�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpIsClear�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F����������Ƃ��ɂ�Text�v���p�e�B�[�����������邩�ǂ���
    ' ���@�l�@�F
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

#Region "pClearText�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpClearText�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����\������text�v���p�e�B�[�̎擾�ݒ�
    ' ���@�l�@�F�h���b�v�_�E���`�����̏����\������B�e�L�X�g�̎擾�ݒ�
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

#Region "pClearUnyoubi�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpClearUnyoubi�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���������s�����Ƃ��ɉ^�p�����Z�b�g���邩
    ' ���@�l�@�F
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

#Region "pYear�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpYear�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�N���擾�ݒ�
    ' ���@�l�@�F
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

#Region "pMonth�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpMonth�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����擾�ݒ�
    ' ���@�l�@�F
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

#Region "pDay�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpDay�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����擾�ݒ�
    ' ���@�l�@�F
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

#Region "pCondition�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpCondition�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͏��,�w�i�F�ύX
    ' ���@�l�@�FEnmCondition���Q��
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

#Region "pErrText�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpErrText�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���̓G���[���ɕ\�������
    ' ���@�l�@�F
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

#Region "pFromToSearch�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpFromToSearch�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FFromTo��EnmFromTo�ōs��
    ' ���@�l�@�FpFromObj�Ɋ���t�����R���g���[���Ƃ͈̔͌������s��
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

#Region "pFromObj�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpFromObj�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FFromTo�̌������s��������From�I�u�W�F�N�g
    ' ���@�l�@�F�����^�̃R���g���[���ł͈̔͌��������܂��B
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

#Region "pFromToErrText�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpFromToErrText�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FFromTo�͈͓��̓G���[���ɕ\�������
    ' ���@�l�@�F
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

    ''�C�x���g-------------------------------------------------------------------
#Region "KeyPress"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FKeyPress
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���l�̂ݓ��͉�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYear.KeyPress, txtMonth.KeyPress, txtDay.KeyPress
        '����
        If Char.IsDigit(e.KeyChar.ToString.Chars(0)) = True Then

            'backspace,enter
        ElseIf Char.IsControl(e.KeyChar.ToString.Chars(0)) = True Then

            '�A���t�@�x�b�g
        ElseIf Char.IsLetter(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            '��؂蕶��
        ElseIf Char.IsPunctuation(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            '�T���Q�[�g����
        ElseIf Char.IsSurrogate(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            '�V���{��
        ElseIf Char.IsSymbol(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            '�X�y�[�X
        ElseIf Char.IsWhiteSpace(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

        Else
        End If

    End Sub

#Region "Enter"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FEnter
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FTEXT��I����Ԃɂ���B
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.Enter, txtMonth.Enter, txtDay.Enter
        CType(sender, TextBox).SelectAll()
    End Sub

#Region "TextChanged"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FTextChanged
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�ő包���͂Ŏ��̓��͂ֈړ�����.
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.TextChanged, txtMonth.TextChanged, txtDay.TextChanged
        ''���[�U�[�R���g���[���̃e�L�X�g�`�F���W�C�x���g�𔭐�������
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
    ' �@�@�\�@�FBackColorChanged
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�F�ύX�œ����̃R���g���[���̐F��ύX����B
    ' ���@�l�@�F
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
    ' �@�@�\�@�FSizeChanged
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�T�C�Y���Œ肷��B
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrDate_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.Size = New System.Drawing.Size(96, 22)
    End Sub

#Region "Leave"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FLeave
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͂�����ꍇ�͂O�l����B
    ' ���@�l�@�F
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
    ' �@�@�\�@�FLeave
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͂�����ꍇ�͂O�l����B
    ' ���@�l�@�F
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
    ' �@�@�\�@�FLeave
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͂�����ꍇ�͂O�l����B
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub txtDay_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDay.Leave, MyBase.Leave
        If Me.txtDay.TextLength > 0 Then
            If Me.txtDay.TextLength < 2 Then
                Me.txtDay.Text = Me.txtDay.Text.PadLeft(2, Chr(Asc("0")))
            End If
        End If
    End Sub

    '���\�b�h-------------------------------------------------------------------
#Region "gSubFocus"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FgSubFocus
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�N�Ƀt�H�[�J�[�X���Z�b�g�B
    ' ���@�l�@�F���̃R���g���[���Ƀt�H�[�J�X���Z�b�g����ꍇ�͂��̃��\�b�h���g���Ă�������
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubFocus()
        Me.txtYear.Focus()
    End Sub

End Class
