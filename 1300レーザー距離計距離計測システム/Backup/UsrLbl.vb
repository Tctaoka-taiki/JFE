'*******************************************************************************
' @(h)  UsrLbl.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrLbl                             System.Windows.Forms.Label���p��
'       �����ݒ肳���쐬�v���p�e�B�[
'       
'       ��L�ȊO�͏����̌^�̒l�ɂȂ�܂��B
'
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ForeColor = System.Drawing.SystemColors.ControlText
'       TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************
Option Explicit On 
Public Class UsrLbl
    Inherits System.Windows.Forms.Label

    Private mLblID As String
    Private mBlnClear As Boolean
    Private mStrClearText As String
    Private mMaxInt As Integer = 5
    Private mMaxDec As Integer = 0
    Private mCharType As EnmCharType = EnmCharType.Numonly

    Public Enum EnmCharType
        Numonly     '����
        Letter      '����
    End Enum

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        Me.mLblID = ""
        Me.mStrClearText = ""
        Me.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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

    End Sub

#End Region

    ''�v���p�e�B�[-------------------------------------------------------------------
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

#Region "pLblID�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpLblID�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pLblID() As String
        Get
            pLblID = mLblID
        End Get
        Set(ByVal Value As String)
            mLblID = Value
        End Set
    End Property

End Class
