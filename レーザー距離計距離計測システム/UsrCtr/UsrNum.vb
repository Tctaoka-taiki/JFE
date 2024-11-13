'*******************************************************************************
' @(h)  UsrNum.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrNum                           System.Windows.Forms.NumericUpDown���p��
'       �����ݒ肳���쐬�v���p�e�B�[
'       pCondition = EnmCondition.Nomal
'       pClearText = "0"
'       pAutoFocus = True
'       pAutoSelect = True
'       ��L�ȊO�͏����̌^�̒l�ɂȂ�܂��B
'
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ThousandsSeparator = True
'       ImeMode = ImeMode.Disable
'       TextAlign = HorizontalAlignment.Right
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************
Option Explicit On 
Public Class UsrNum
    Inherits System.Windows.Forms.NumericUpDown

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
    Private mBlnAutoFocus As Boolean
    Private mBlnAutoSelect As Boolean
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
        Me.mStrClearText = "0"
        Me.mBlnAutoFocus = True
        Me.mBlnAutoSelect = True
        Me.ThousandsSeparator = True
        Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.mImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.mCondition = EnmCondition.Nomal
        Me.mFromToSearch = EnmFromTo.None
        Me.ImeMode = Windows.Forms.ImeMode.Disable
        Me.TextAlign = HorizontalAlignment.Right
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
        components = New System.ComponentModel.Container
    End Sub

#End Region

    ''�v���p�e�B�[-------------------------------------------------------------------
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
#Region "Enter"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FEnter
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[�J�X�擾���ɕ����I��
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrNum_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        ''�J���}��؂薳
        Me.ThousandsSeparator = False

        ''�����I��
        If Me.mBlnAutoSelect Then
            If Me.Text.Length > 0 Then
                Me.Select(0, Me.Text.Length)
            End If
        End If
    End Sub

#Region "Leave"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FLeave
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[�J�X�������ɐ��l����
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrNum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        ''�J���}��؂�L��
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
