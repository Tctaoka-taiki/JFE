'*******************************************************************************
' @(h)  MMain.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  �O���[�o���ϐ�
'*******************************************************************************
Imports System.Data.Odbc
Imports Oracle.DataAccess.Client
Module MMain
    ''ID
    Public gstrID As String '�[��ID

    ''�@�BNO
    Public gstr�@�BNO As String '�I������Ă���@�BNO
    ''�S����CD
    Public gstr�S����CD As String '�I������Ă��钼(�S����CD)

    ''���������H
    Public gstr���HNO As String = ""
    Public gstr�q�� As String = ""
    Public gstr�Z�b�gNO As String = ""
    Public gstr�J�b�gNO As String = ""
    Public gstr�ŏI�Z�b�g�J�b�g As String = ""
    Public gstr�ŏ��Z�b�g�J�b�g As String = ""


    ''�N�����[�h
    Public gMode_�����e As Boolean

    ''�ڑ����[�h
    Public gMode_�ڑ� As gEnm�ڑ� = MConst.gEnm�ڑ�.ORACLE

    ''���Ə��R�[�h
    Public gstr���Ə��R�[�h As String

    ''���ѓ��͉�ʂŎd�l
    'Public gcla���� As C���ѓ���

    ''�N��
    'Public gcla���[�J�N�� As C���ѓ���.c���ѓ���_���l
    'Public gcla�Г��N�� As C���ѓ���.c���ѓ���_���l

    '''�G���[���O�N���X
    'Public gclaLOG As New CLog

    ''�_�C�A���O
    'Public gDia�e���L�[ As dia0001_TenKey            ''�t�H�[������Ăяo���e���L�[
    'Public gDia�e���L�[_Dia As dia0002_TenKey_dia    ''�_�C�A���O����Ăяo���e���L�[

    '''2005/08/24(K) �f�o�b�O�p
    'Public gDia��Ǝ��ԓo�^ As dia9001_��Ǝ��ԓo�^

    'Public gDia���H�w�������s As dia1001_���H�w�������s
    'Public gDia�����L�^�\���s As dia1002_�����L�^�\���s
    'Public gDia���x�����s As dia1003_���x�����s
    'Public gDia�@�B�ԍ��I�� As dia1004_�@�B�ԍ��I��
    'Public gDia���яd�ʓ��� As dia1005_���яd�ʓ���
    'Public gDia��Q���ԓ��� As dia1006_��Q���ԓ���
    'Public gDia������ As dia1007_������
    'Public gDia�[���� As dia1008_�[����
    'Public gDia�[����_�ڍ� As dia1009_�[����_�ڍ�
    'Public gDia�N���[���������� As dia1010_�N���[����������
    'Public gDia�݋���� As dia1011_�݋����

    'Public gDia�Z�b�g�ύX As dia1101_�Z�b�g�ύX

    'Public gDia���H�w���Ɖ�� As dia2101_���H�w���Ɖ��

    'Public gDia�i���d�l���s As dia3101_�i���d�l���s
    'Public gDia��Ɠ��񔭍s As dia2201_��Ɠ��񔭍s
    'Public gDia�����ގ�z�\���s As dia2202_�����ގ�z�\���s

    'Public gDia�N���[���������� As dia3201_�N���[����������

    'Public gDia�o�͐�I�� As dia5001_�o�͐�I��
    'Public gDia�@�B�o�^ As dia5002_�@�B�o�^

    Public gstrPLSQL���O As String
    Public gblnPLSQL�ۑ��L As Boolean
    Public gstr���O�t�@�C���o�͐� As String
    Public gbln���O�t�@�C���L�� As Boolean

#Region "�_�C�A���O�����ʒu"
    Public gTop_�e���L�[ As Integer = 518
    Public gLeft_�e���L�[ As Integer = 866
    Public gTop_�e���L�[_Dia As Integer = 457
    Public gLeft_�e���L�[_Dia As Integer = 826
    Public gTop_���H�w�������s As Integer = 80
    Public gLeft_���H�w�������s As Integer = 608
    Public gTop_�����L�^�\���s As Integer = 80
    Public gLeft_�����L�^�\���s As Integer = 29
    Public gTop_���x�����s As Integer = 446
    Public gLeft_���x�����s As Integer = 281
    Public gTop_�@�B�ԍ��I�� As Integer = 60
    Public gLeft_�@�B�ԍ��I�� As Integer = 93
    Public gTop_���яd�ʓ��� As Integer = 501
    Public gLeft_���яd�ʓ��� As Integer = 10
    Public gTop_��Q���ԓ��� As Integer = 171
    Public gLeft_��Q���ԓ��� As Integer = 487
    Public gTop_������ As Integer = 56
    Public gLeft_������ As Integer = 130
    Public gTop_�[���� As Integer = 199
    Public gLeft_�[���� As Integer = 196
    Public gTop_�[����_�ڍ� As Integer = 402
    Public gLeft_�[����_�ڍ� As Integer = 198
    Public gTop_�N���[���������� As Integer = 201
    Public gLeft_�N���[���������� As Integer = 890
    Public gTop_�݋���� As Integer = 136
    Public gLeft_�݋���� As Integer = 179

    Public gTop_�Z�b�g�ύX As Integer = 385
    Public gLeft_�Z�b�g�ύX As Integer = 340

    Public gTop_���H�w���Ɖ�� As Integer = 518
    Public gLeft_���H�w���Ɖ�� As Integer = 866

    Public gTop_�i���d�l���s As Integer = 540
    Public gLeft_�i���d�l���s As Integer = 22
    Public gTop_��Ɠ��񔭍s As Integer = 540
    Public gLeft_��Ɠ��񔭍s As Integer = 22
    Public gTop_�����ގ�z�\���s As Integer = 400
    Public gLeft_�����ގ�z�\���s As Integer = 400

    Public gTop_�N���[���������� As Integer = 137
    Public gLeft_�N���[���������� As Integer = 62

    Public gTop_�o�͐�I�� As Integer = 19
    Public gLeft_�o�͐�I�� As Integer = 762
    Public gTop_�@�B�o�^ As Integer = 54
    Public gLeft_�@�B�o�^ As Integer = 481

#End Region

    ''���b�Z�[�W�{�b�N�X
    Public Sub gMsg_����(ByVal strMsg As String)
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.����, strMsg)
        'Call diaMsg.ShowDialog()
    End Sub
    Public Sub gMsg_���(ByVal strMsg As String)
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.���, strMsg)
        'Call diaMsg.ShowDialog()
    End Sub
    Public Sub gMsg_�x��(ByVal strMsg As String)
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.�x��, strMsg)
        'Call diaMsg.ShowDialog()
    End Sub

    Public Function gMsg_YesNo(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.YesNo, strMsg)
        'Return diaMsg.ShowDialog()
    End Function
    Public Function gMsg_YesNoCancel(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.YesNoCancel, strMsg)
        'Return diaMsg.ShowDialog
    End Function

    Public Function gInt(ByVal strInt As String) As Integer
        If strInt.TrimEnd = "" Then
            Return 0
        ElseIf IsNumeric(strInt) = False Then
            Return 0
        Else
            Return CInt(strInt)
        End If
    End Function
    Public Function gDbl(ByVal strInt As String) As Double
        If strInt.TrimEnd = "" Then
            Return 0
        ElseIf IsNumeric(strInt) = False Then
            Return 0
        Else
            Return CDbl(strInt)
        End If
    End Function

    ''���t�ϊ��֐�8����/������-------------------------------------------------------------------------------------------------
    Public Function gStrFormat���t(ByVal str���t As String) As String
        Dim strBuff As String
        If str���t.Length <> 8 Then
            Return str���t
        Else
            strBuff = str���t.Substring(0, 4) & "/" & str���t.Substring(4, 2) & "/" & str���t.Substring(6, 2)
            Return strBuff
        End If
    End Function
    '14����Cdate�ɂ�����邩�����ɂ���
    Public Function gStrFormat����(ByVal str���� As String) As String
        Dim strBuff As String
        If str����.Length <> 14 Then
            Return str����
        Else
            strBuff = str����.Substring(0, 4) & "/" & str����.Substring(4, 2) & "/" & str����.Substring(6, 2) & " " & str����.Substring(8, 2) & ":" & str����.Substring(10, 2) & ":" & str����.Substring(12, 2)
            Return strBuff
        End If
    End Function

End Module
