'*******************************************************************************
' @(h)  UsrOpt.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrOpt                             System.Windows.Forms.RadioButton���p��
'       �����ݒ肳���쐬�v���p�e�B�[
'       
'       ��L�ȊO�͏����̌^�̒l�ɂȂ�܂��B
'
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************
Option Explicit On 
Public Class UsrOpt
    Inherits System.Windows.Forms.RadioButton

    Private mBlnClearChecked As Boolean
    Private mBlnClear As Boolean 
    Private mFocusColor As New System.Drawing.Color
    Private mDefaultColor As New System.Drawing.Color
    Private mOptID As String

#Region " �R���|�[�l���g �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���́A�R���|�[�l���g �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        Me.mOptID = ""
        Me.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.pIsClear = True
        ''�t�H�[�J�X���̐F
        Me.mFocusColor = System.Drawing.Color.Yellow
        Me.mDefaultColor = Me.BackColor
    End Sub

    'Control �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂ɁAdispose �����s���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    '�R���g���[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���̓R���|�[�l���g �f�U�C�i�ŕK�v�ł��B
    ' �R���|�[�l���g �f�U�C�i���g���ĕύX�ł��܂��B�R�[�h �G�f�B�^��
    ' �g���ĕύX���Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
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

#Region "pClearChecked�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpClearChecked�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����\���̂�Checkd
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pClearChecked() As Boolean
        Get
            pClearChecked = Me.mBlnClearChecked
        End Get
        Set(ByVal Value As Boolean)
            Me.mBlnClearChecked = Value
        End Set
    End Property

#Region "pDefBackcolor"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpDefBackcolor
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����̐F
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pDefBackcolor() As Color
        Get
            Return mDefaultColor
        End Get
        Set(ByVal Value As Color)
            Me.mDefaultColor = Value
        End Set
    End Property

#Region "pOptID�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpOptID�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FID�̎擾�ݒ�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pOptID() As String
        Get
            pOptID = mOptID
        End Get
        Set(ByVal Value As String)
            mOptID = Value
        End Set
    End Property

    ''�I�[�o�[���C�h-------------------------------------------------------------------
    Protected Overrides Sub OnCheckedChanged(ByVal e As System.EventArgs)
        MyBase.OnCheckedChanged(e)
        If Me.Appearance = Windows.Forms.Appearance.Button Then
            If Me.Checked Then
                Me.BackColor = Me.mFocusColor
            Else
                Me.BackColor = Me.mDefaultColor
            End If
        End If
    End Sub
End Class
