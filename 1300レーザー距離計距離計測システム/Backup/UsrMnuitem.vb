'*******************************************************************************
' @(h)  UsrMnuitem.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrMnuitem                             System.Windows.Forms.MenuItem���p��
'       
'*******************************************************************************
Option Explicit On 
Public Class UsrMnuitem
    Inherits System.Windows.Forms.MenuItem

    Private mFormID As String
    Private mMnuName As String

    ''�v���p�e�B�[-------------------------------------------------------------------
#Region "pFormID�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpFormID�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�\��������ID�̎擾�ݒ�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pFormID() As String
        Get
            pFormID = Me.mFormID
        End Get
        Set(ByVal Value As String)
            Me.mFormID = Value
        End Set
    End Property

#Region "pMnuName"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpMnuName�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�e���j���[�̕\����TEXT�v���p�e�B�[�ցA�B���ŉ�ʖ����Z�b�g����B
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pMnuName() As String
        Get
            pMnuName = Me.mMnuName
        End Get
        Set(ByVal Value As String)
            Me.mMnuName = Value
        End Set
    End Property
End Class
