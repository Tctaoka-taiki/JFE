'*******************************************************************************
' @(h)  UsrBtn.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrBtn                             System.Windows.Forms.Button���p��
'       �����ݒ肳���쐬�v���p�e�B�[
'       pMoveForm = enmMoveForm.AllCloseOpen
'       ��L�ȊO�͏����̌^�̒l�ɂȂ�܂��B
'
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************
Option Explicit On 
Public Class UsrBtn
    Inherits System.Windows.Forms.Button

    Private mBtnID As String
    Private mFuncKey As String
    Private mMoveForm As enmMoveForm
    Private mFocusColor As New System.Drawing.Color()
    Private mBlnClear As Boolean

    Public Enum enmMoveForm
        AllCloseOpen   '���ׂĂ̎q�t�H�[�������pBtnID��ʂ�\��
        NotCloseOpen   '��ʂ������pBtnID��ʂ�\��
        MeCloseIDopen  '�����͕���pBtnID��ʂ�\��
        IDActiveOpen   'pBtnID��ʂ����łɊJ���Ă�����A�N�e�B�u�A�J���ĂȂ��ꍇ�͊J��
    End Enum

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        Me.mBtnID = ""
        Me.mFuncKey = ""
        Me.mMoveForm = enmMoveForm.AllCloseOpen
        Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        ''�t�H�[�J�X���̐F
        Me.mFocusColor = System.Drawing.Color.LightGreen
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
        'UsrBtn
        '

    End Sub

#End Region

    ''�v���p�e�B�[-------------------------------------------------------------------
#Region "pFuncKey�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpFuncKey�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���蓖�Ă�t�@���N�V�����L�[
    ' ���@�l�@�F�i��@F1�����蓖�Ă�B"F1"�BSHIFT+F1�����蓖�Ă�B"SF1"
    '---------------------------------------------------------------------------
#End Region
    Public Property pFuncKey() As String
        Get
            pFuncKey = mFuncKey
        End Get
        Set(ByVal Value As String)
            mFuncKey = Value
        End Set
    End Property

#Region "pMoveForm�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpMoveForm�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F��ʈړ�����Ƃ��̐��������B
    ' ���@�l�@�F�ړ����@��enmMoveForm���Q��
    '---------------------------------------------------------------------------
#End Region
    Public Property pMoveForm() As enmMoveForm
        Get
            pMoveForm = mMoveForm
        End Get
        Set(ByVal Value As enmMoveForm)
            mMoveForm = Value
        End Set
    End Property

#Region "pBtnID�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpBtnID�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�ړ����ID�̎擾�ݒ�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pBtnID() As String
        Get
            pBtnID = mBtnID
        End Get
        Set(ByVal Value As String)
            mBtnID = Value
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

    ''�I�[�o�[���C�h-------------------------------------------------------------------
#Region "�t�H�[�J�X�擾���̐F�ύX(�I�[�o�[���C�h)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�t�H�[�J�X�擾���̐F�ύX
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[�J�X�擾���̐F�ύX
    ' ���@�l�@�F�I�[�o�[���C�h
    '---------------------------------------------------------------------------
#End Region
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        MyBase.OnGotFocus(e)
    End Sub

#Region "�t�H�[�J�X�������̐F�ύX(�I�[�o�[���C�h)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�t�H�[�J�X�������̐F�ύX
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[�J�X�������̐F�ύX
    ' ���@�l�@�F�I�[�o�[���C�h
    '---------------------------------------------------------------------------
#End Region
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        'Me.BackColor = Me.DefaultBackColor
    End Sub

#Region "�W���T�C�Y(�I�[�o�[���C�h)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�W���T�C�Y
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[���Ƀ{�^����z�u�����Ƃ��̕W���T�C�Y�̕ύX
    ' ���@�l�@�F�I�[�o�[���C�h
    '---------------------------------------------------------------------------
#End Region
    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            DefaultSize = New System.Drawing.Size(73, 33)
        End Get
    End Property
End Class
