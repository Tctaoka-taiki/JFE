Public Class UsrTenKey
    Inherits System.Windows.Forms.UserControl

    Private mBlnselectWaku As Boolean
    Private mMaxInt As Integer = 5
    Private mMaxDec As Integer = 0
    Private mCharType As EnmCharType = EnmCharType.Numonly

    Public Enum EnmCharType
        Numonly     '����
        Letter      '����
    End Enum

    Public Event evtClose_Clic()
    Public Event evtInput_Clic()

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        Me.Size = New System.Drawing.Size(252, 344)

    End Sub

    'UserControl �̓R���|�[�l���g�ꗗ���������邽�߂� dispose ���I�[�o�[���C�h���܂��B
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
    'Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
    Friend WithEvents btn���� As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn���� As System.Windows.Forms.Button
    Friend WithEvents btn���� As System.Windows.Forms.Button
    Friend WithEvents btn�_ As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btnAC As System.Windows.Forms.Button
    Friend WithEvents lbl�\�� As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btn���� = New System.Windows.Forms.Button
        Me.btn9 = New System.Windows.Forms.Button
        Me.btn8 = New System.Windows.Forms.Button
        Me.btn7 = New System.Windows.Forms.Button
        Me.btn6 = New System.Windows.Forms.Button
        Me.btn5 = New System.Windows.Forms.Button
        Me.btn4 = New System.Windows.Forms.Button
        Me.btn3 = New System.Windows.Forms.Button
        Me.btn2 = New System.Windows.Forms.Button
        Me.btn1 = New System.Windows.Forms.Button
        Me.btn���� = New System.Windows.Forms.Button
        Me.btn���� = New System.Windows.Forms.Button
        Me.btn�_ = New System.Windows.Forms.Button
        Me.btn0 = New System.Windows.Forms.Button
        Me.btnAC = New System.Windows.Forms.Button
        Me.lbl�\�� = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btn����
        '
        Me.btn����.BackColor = System.Drawing.SystemColors.Control
        Me.btn����.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn����.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn����.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn����.Location = New System.Drawing.Point(172, 284)
        Me.btn����.Name = "btn����"
        Me.btn����.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn����.Size = New System.Drawing.Size(73, 52)
        Me.btn����.TabIndex = 2
        Me.btn����.Text = "����"
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.SystemColors.Control
        Me.btn9.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn9.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn9.Location = New System.Drawing.Point(172, 48)
        Me.btn9.Name = "btn9"
        Me.btn9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn9.Size = New System.Drawing.Size(73, 53)
        Me.btn9.TabIndex = 12
        Me.btn9.Text = "9"
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.SystemColors.Control
        Me.btn8.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn8.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn8.Location = New System.Drawing.Point(92, 48)
        Me.btn8.Name = "btn8"
        Me.btn8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn8.Size = New System.Drawing.Size(73, 53)
        Me.btn8.TabIndex = 13
        Me.btn8.Text = "8"
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.SystemColors.Control
        Me.btn7.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn7.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn7.Location = New System.Drawing.Point(12, 48)
        Me.btn7.Name = "btn7"
        Me.btn7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn7.Size = New System.Drawing.Size(73, 53)
        Me.btn7.TabIndex = 14
        Me.btn7.Text = "7"
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.SystemColors.Control
        Me.btn6.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn6.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn6.Location = New System.Drawing.Point(172, 108)
        Me.btn6.Name = "btn6"
        Me.btn6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn6.Size = New System.Drawing.Size(73, 53)
        Me.btn6.TabIndex = 9
        Me.btn6.Text = "6"
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.SystemColors.Control
        Me.btn5.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn5.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn5.Location = New System.Drawing.Point(92, 108)
        Me.btn5.Name = "btn5"
        Me.btn5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn5.Size = New System.Drawing.Size(73, 53)
        Me.btn5.TabIndex = 10
        Me.btn5.Text = "5"
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.SystemColors.Control
        Me.btn4.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn4.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn4.Location = New System.Drawing.Point(12, 108)
        Me.btn4.Name = "btn4"
        Me.btn4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn4.Size = New System.Drawing.Size(73, 53)
        Me.btn4.TabIndex = 11
        Me.btn4.Text = "4"
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.SystemColors.Control
        Me.btn3.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn3.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn3.Location = New System.Drawing.Point(172, 168)
        Me.btn3.Name = "btn3"
        Me.btn3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn3.Size = New System.Drawing.Size(73, 53)
        Me.btn3.TabIndex = 6
        Me.btn3.Text = "3"
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.SystemColors.Control
        Me.btn2.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn2.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn2.Location = New System.Drawing.Point(92, 168)
        Me.btn2.Name = "btn2"
        Me.btn2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn2.Size = New System.Drawing.Size(73, 53)
        Me.btn2.TabIndex = 7
        Me.btn2.Text = "2"
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.SystemColors.Control
        Me.btn1.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn1.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn1.Location = New System.Drawing.Point(12, 168)
        Me.btn1.Name = "btn1"
        Me.btn1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn1.Size = New System.Drawing.Size(73, 53)
        Me.btn1.TabIndex = 8
        Me.btn1.Text = "1"
        '
        'btn����
        '
        Me.btn����.BackColor = System.Drawing.SystemColors.Control
        Me.btn����.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn����.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn����.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn����.Location = New System.Drawing.Point(92, 284)
        Me.btn����.Name = "btn����"
        Me.btn����.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn����.Size = New System.Drawing.Size(73, 52)
        Me.btn����.TabIndex = 16
        Me.btn����.Text = "��"
        '
        'btn����
        '
        Me.btn����.BackColor = System.Drawing.SystemColors.Control
        Me.btn����.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn����.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn����.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn����.Location = New System.Drawing.Point(172, 228)
        Me.btn����.Name = "btn����"
        Me.btn����.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn����.Size = New System.Drawing.Size(73, 52)
        Me.btn����.TabIndex = 3
        Me.btn����.Text = "����"
        '
        'btn�_
        '
        Me.btn�_.BackColor = System.Drawing.SystemColors.Control
        Me.btn�_.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn�_.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn�_.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn�_.Location = New System.Drawing.Point(92, 228)
        Me.btn�_.Name = "btn�_"
        Me.btn�_.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn�_.Size = New System.Drawing.Size(73, 52)
        Me.btn�_.TabIndex = 4
        Me.btn�_.Text = "."
        Me.btn�_.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.SystemColors.Control
        Me.btn0.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn0.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn0.Location = New System.Drawing.Point(12, 228)
        Me.btn0.Name = "btn0"
        Me.btn0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn0.Size = New System.Drawing.Size(73, 52)
        Me.btn0.TabIndex = 5
        Me.btn0.Text = "0"
        '
        'btnAC
        '
        Me.btnAC.BackColor = System.Drawing.SystemColors.Control
        Me.btnAC.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAC.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAC.Location = New System.Drawing.Point(12, 284)
        Me.btnAC.Name = "btnAC"
        Me.btnAC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAC.Size = New System.Drawing.Size(73, 52)
        Me.btnAC.TabIndex = 17
        Me.btnAC.Text = "�`�b"
        '
        'lbl�\��
        '
        Me.lbl�\��.BackColor = System.Drawing.SystemColors.HighlightText
        Me.lbl�\��.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl�\��.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl�\��.Location = New System.Drawing.Point(20, 12)
        Me.lbl�\��.Name = "lbl�\��"
        Me.lbl�\��.Size = New System.Drawing.Size(217, 31)
        Me.lbl�\��.TabIndex = 15
        Me.lbl�\��.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(4, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 332)
        Me.Label2.TabIndex = 1
        '
        'UsrTenKey
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.lbl�\��)
        Me.Controls.Add(Me.btn����)
        Me.Controls.Add(Me.btn9)
        Me.Controls.Add(Me.btn8)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.btn����)
        Me.Controls.Add(Me.btn����)
        Me.Controls.Add(Me.btn�_)
        Me.Controls.Add(Me.btn0)
        Me.Controls.Add(Me.btnAC)
        Me.Controls.Add(Me.Label2)
        Me.Name = "UsrTenKey"
        Me.Size = New System.Drawing.Size(252, 344)
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
            If Me.lbl�\��.Text.Length = 0 Then
                Select Case Me.mCharType
                    Case EnmCharType.Numonly
                        If Me.mMaxDec > 0 Then
                            Text = Format("0." & StrDup(Me.mMaxDec, Convert.ToChar("0")))
                        Else
                            Text = "0"
                        End If

                    Case Else
                        Text = ""
                End Select
            Else
                Select Case Me.mCharType
                    Case EnmCharType.Numonly
                        If Me.mMaxDec > 0 Then
                            Text = Format(CDbl(Me.lbl�\��.Text), "0." & StrDup(Me.mMaxDec, Convert.ToChar("0")))
                        Else
                            Text = CStr(CDbl(Me.lbl�\��.Text))
                        End If
                    Case EnmCharType.Letter
                        Text = Me.lbl�\��.Text
                End Select
            End If
        End Get
        Set(ByVal Value As String)
            Me.lbl�\��.Text = Value
        End Set
    End Property

#Region "pmMaxInt"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpmMaxInt
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͂ł��鐮���̐��l����
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pMaxInt() As Integer
        Get
            pMaxInt = Me.mMaxInt
        End Get
        Set(ByVal Value As Integer)
            Me.mMaxInt = Value
        End Set
    End Property

#Region "pMaxDec"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpMaxDec
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͂ł��鏬���_�ȉ��̐��l����
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pMaxDec() As Integer
        Get
            pMaxDec = Me.mMaxDec
        End Get
        Set(ByVal Value As Integer)
            Me.mMaxDec = Value
        End Set
    End Property

#Region "pCharType�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpCharType�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͕�������
    ' ���@�l�@�FEnmCharType���Q��
    '---------------------------------------------------------------------------
#End Region
    Public Property pCharType() As EnmCharType
        Get
            pCharType = Me.mCharType
        End Get
        Set(ByVal Value As EnmCharType)
            Me.mCharType = Value
            Select Case Me.mCharType
                Case EnmCharType.Numonly
                    'Me.lbl�\��.Text = "0"
                    Me.lbl�\��.Text = ""
                Case EnmCharType.Letter
                    Me.lbl�\��.Text = ""
            End Select
        End Set
    End Property

    '�C�x���g-------------------------------------------------------------------
#Region "btn����_Click"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�Fbtn����_Click
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F
    ' ���@�l�@�FevtClose_Clic�̔���
    '---------------------------------------------------------------------------
#End Region
    Private Sub btn����_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn����.Click
        RaiseEvent evtClose_Clic()
    End Sub

#Region "btn����_Click"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�Fbtn����_Click
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F
    ' ���@�l�@�FevtInput_Clic�̔���
    '---------------------------------------------------------------------------
#End Region
    Private Sub btn����_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn����.Click
        RaiseEvent evtInput_Clic()
    End Sub

#Region "btnNum_Click"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FbtnNum_Click
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���l�̓���
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub btnNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Try
            Select Case Me.mCharType
                Case EnmCharType.Numonly
                    If Me.mMaxInt + Me.mMaxDec = 0 Then
                        Exit Sub
                    End If
                    Dim intDecPoint As Integer
                    intDecPoint = InStr(Me.lbl�\��.Text, Me.btn�_.Text)
                    If intDecPoint = 0 Then
                        If Me.lbl�\��.Text = "0" Then
                            Me.lbl�\��.Text = CStr(CInt(Me.lbl�\��.Text & CType(sender, Button).Text))
                        ElseIf Me.lbl�\��.Text.Length < Me.mMaxInt Then
                            Me.lbl�\��.Text = CStr(CInt(Me.lbl�\��.Text & CType(sender, Button).Text))
                        End If
                    Else
                        Dim intDecLen As Integer
                        intDecLen = Me.lbl�\��.Text.Length - intDecPoint
                        If intDecLen < Me.mMaxDec Then
                            Me.lbl�\��.Text = Me.lbl�\��.Text & CType(sender, Button).Text
                        End If
                    End If

                Case EnmCharType.Letter
                    If Me.lbl�\��.Text.Length < Me.mMaxInt Then
                        Me.lbl�\��.Text = Me.lbl�\��.Text & CType(sender, Button).Text
                    End If
            End Select

        Catch ex As Exception
            Call MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "btn�__Click"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�Fbtn�__Click
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����_�̓���
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub btn�__Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�_.Click
        Try
            Select Case Me.mCharType
                Case EnmCharType.Numonly
                    If Me.mMaxDec > 0 Then
                        If InStr(Me.lbl�\��.Text, Me.btn�_.Text) = 0 Then
                            If Me.lbl�\��.Text.Length = 0 Then
                                Me.lbl�\��.Text = "0" & Me.btn�_.Text
                            Else
                                Me.lbl�\��.Text = Me.lbl�\��.Text & Me.btn�_.Text
                            End If
                        End If
                    End If

                Case EnmCharType.Letter
                    Exit Sub
            End Select

        Catch ex As Exception
            Call MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "btnAC_Click"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FbtnAC_Click
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�\���̃N���A
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub btnAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAC.Click
        Try
            Select Case Me.mCharType
                Case EnmCharType.Numonly
                    'Me.lbl�\��.Text = "0"
                    Me.lbl�\��.Text = ""
                Case EnmCharType.Letter
                    Me.lbl�\��.Text = ""
            End Select

        Catch ex As Exception
            Call MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "btn����_Click"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�Fbtn����_Click
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�P��������
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub btn����_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn����.Click
        Try
            Select Case Me.lbl�\��.Text.Length
                Case 0, 1
                    Select Case Me.mCharType
                        Case EnmCharType.Numonly
                            'Me.lbl�\��.Text = "0"
                            Me.lbl�\��.Text = ""
                        Case EnmCharType.Letter
                            Me.lbl�\��.Text = ""
                    End Select
                Case Else
                    Me.lbl�\��.Text = Me.lbl�\��.Text.Substring(0, Me.lbl�\��.Text.Length - 1)
            End Select

        Catch ex As Exception
            Call MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "UsrTenKey_SizeChanged"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FUsrTenKey_SizeChanged
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�T�C�Y�̒���
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrTenKey_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Try
            Me.Size = New System.Drawing.Size(252, 344)
        Catch ex As Exception
            Call MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
