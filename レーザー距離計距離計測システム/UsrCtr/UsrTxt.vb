'*******************************************************************************
' @(h)  UsrTxt.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrTxt                             System.Windows.Forms.TextBox���p��
'       �����ݒ肳���쐬�v���p�e�B�[
'       pCharType = Me.EnmCharType.All
'       pAutoFocus = True
'       pAutoSelect = True
'       pCondition = EnmCondition.Nomal
'       ��L�ȊO�͏����̌^�̒l�ɂȂ�܂��B
'
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************
Option Explicit On 
Public Class UsrTxt
    Inherits System.Windows.Forms.TextBox

    Public Enum EnmCharType
        Numonly     '�����̂�
        Letter      '�����̂�
        NumLetter   '����������
        All         '���͐����Ȃ�
        WildNumonly     '�����̂� + *
        WildLetter      '�����̂� + *
        WildNumLetter   '���������� + *
    End Enum

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

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        Me.mStrClearText = ""
        Me.mStrErrText = ""
        Me.mStrFromToErrText = ""
        Me.mBlnAutoFocus = True
        Me.mBlnAutoSelect = True
        Me.mCharType = UsrTxt.EnmCharType.All
        Me.mCondition = EnmCondition.Nomal
        Me.mFromToSearch = EnmFromTo.None
        Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.mImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.pIsClear = True
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
    ' Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^�͎g�p���Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'UsrTxt
        '

    End Sub

#End Region

    ''�v���p�e�B�[-------------------------------------------------------------------
#Region "pMaxByte"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpMaxByte
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͂ł���o�C�g��(0�͖�����)
    ' ���@�l�@�FMaxLength�v���p�e�B�[�͕������̐����ɂȂ�̂Ŏg�p���Ȃ��ŉ������B
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

#Region "pAutoFocus�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpAutoFocus�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�ő包�����͎��Ɏ��̃R���g���[���Ɉړ����邩
    ' ���@�l�@�FTRUE=�ړ�����AFALSE=�ړ����Ȃ�
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

#Region "pAutoSelect�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpAutoSelect�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[�J�X�擾���ɕ����I�����邩
    ' ���@�l�@�FTRUE=�I������AFALSE=�I�����Ȃ�
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
    ' �@�\�����F�����\������text
    ' ���@�l�@�F
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
    ' �@�\�����F���͕�����ChrType�ɂ�萧�����܂�
    ' ���@�l�@�F
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

        '����
        If Char.IsDigit(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All, UsrTxt.EnmCharType.Numonly, EnmCharType.NumLetter, EnmCharType.WildNumonly, EnmCharType.WildNumLetter

                Case Else
                    e.Handled = True
            End Select

            'backspace,enter
        ElseIf Char.IsControl(e.KeyChar) Then

            '�A���t�@�x�b�g
        ElseIf Char.IsLetter(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All, UsrTxt.EnmCharType.Letter, EnmCharType.NumLetter, EnmCharType.WildLetter, EnmCharType.WildNumLetter

                Case Else
                    e.Handled = True
            End Select

            '��؂蕶��
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

            '�T���Q�[�g����
        ElseIf Char.IsSurrogate(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All

                Case Else
                    e.Handled = True
            End Select

            '�V���{��
        ElseIf Char.IsSymbol(e.KeyChar) Then
            Select Case Me.mCharType
                Case UsrTxt.EnmCharType.All

                Case Else
                    e.Handled = True
            End Select

            '�X�y�[�X
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
    ' �@�@�\�@�FTextChanged
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�ő包���Ń^�u�L�[�̓���
    ' ���@�l�@�F
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
            ''�\�t�ŋ��̂Ȃ��������폜(�S�p)
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

            ''�\�t�ŋ��̂Ȃ��������폜(���l����)
            If Me.pCharType <> EnmCharType.All Then
                For i = 0 To strBuff.Length - 1
                    Select Case True
                        ''���l
                    'Case strBuff.Chars(i).IsDigit(strBuff.Chars(i))
                     Case Char.IsDigit(strBuff.Chars(i))
                            Select Case Me.pCharType
                                Case EnmCharType.Numonly, EnmCharType.NumLetter, EnmCharType.WildNumonly, EnmCharType.WildNumLetter
                                    strBuff2 = strBuff2 & strBuff.Chars(i)
                                Case Else

                            End Select
                            ''����
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

            ''�\�t�Ő������z���Ă���ꍇ
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
    ' �@�@�\�@�FEnter
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[�J�X�擾���ɐ��l���͎��́u,�v���Ƃ�A�����I��
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrTxt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        ''�����I��
        If Me.mBlnAutoSelect Then
            Me.SelectAll()
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_PASTE As Integer = &H302

        Select Case m.Msg
            Case WM_PASTE   ''�\��t�����b�Z�[�W
                Me.mBlnPaste = True
                MyBase.WndProc(m)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

End Class
