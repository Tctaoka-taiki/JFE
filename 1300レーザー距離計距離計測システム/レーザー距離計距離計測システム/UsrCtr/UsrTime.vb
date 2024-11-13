'*******************************************************************************
' @(h)  UsrLocation.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrLocation                             System.Windows.Forms.UserControl���p��
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
Public Class UsrTime
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
        Me.lblSura.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSura.Location = New System.Drawing.Point(20, 1)
        Me.lblSura.Name = "lblSura"
        Me.lblSura.Size = New System.Drawing.Size(13, 18)
        Me.lblSura.TabIndex = 10
        Me.lblSura.Text = "�F"
        Me.lblSura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMin
        '
        Me.txtMin.AutoSize = False
        Me.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMin.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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
        Me.txtHour.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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

    ''�v���p�e�B�[-------------------------------------------------------------------
#Region "TEXT�v���p�e�B�[(�I�[�o�[���C�h)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FTEXT�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���Ԃ� : ����Ŏ擾����B
    ' ���@�l�@�F�Z�b�g����ꍇ�� : �Ȃ��ł���
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

#Region "pTextUser�v���p�e�B�[(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpTextUser�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���Ԍ`���ł�Text
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pTextUser() As String
        Get
            pTextUser = Me.txtHour.Text & ":" & Me.txtMin.Text
        End Get
    End Property

#Region "pIsTime�v���p�e�B�[(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpIsDate�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���ԂƂ��Đ�������
    ' ���@�l�@�F
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

#Region "pHour�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpHour�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���Ԃ��擾�ݒ�
    ' ���@�l�@�F
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

#Region "pMin�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpMin�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����擾�ݒ�
    ' ���@�l�@�F
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
    Private Sub UsrDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMin.KeyPress, txtHour.KeyPress
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
    Private Sub UsrDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMin.Enter, txtHour.Enter
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
    Private Sub UsrDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMin.TextChanged, txtHour.TextChanged
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
        Me.txtHour.BackColor = Me.BackColor
        Me.txtMin.BackColor = Me.BackColor
        Me.lblSura.BackColor = Me.BackColor
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
        Me.Size = New System.Drawing.Size(58, 22)
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
    ' �@�@�\�@�FLeave
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͂�����ꍇ�͂O�l����B
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub txtMin_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMin.Leave, MyBase.Leave
        If Me.txtMin.TextLength > 0 Then
            If Me.txtMin.TextLength < 2 Then
                Me.txtMin.Text = Me.txtMin.Text.PadLeft(2, Chr(Asc("0")))
            End If
        End If
    End Sub

    ''���\�b�h-------------------------------------------------------------------
#Region "gSubFocus"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FgSubFocus
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���ԂɃt�H�[�J�[�X���Z�b�g�B
    ' ���@�l�@�F���̃R���g���[���Ƀt�H�[�J�X���Z�b�g����ꍇ�͂��̃��\�b�h���g���Ă�������
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubFocus()
        Me.txtHour.Focus()
    End Sub

End Class
