'*******************************************************************************
' @(h)  CLog.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  �V�X�e�����O�A�I�y���[�V�������O�̓o�^�B
'*******************************************************************************
Imports System.Text
Imports System.Windows.Forms
'Imports Oracle.DataAccess.Client
Public Class CLog

    ''�R���X�g���N�^---------------------------------------------------------------------------
#Region "�R���X�g���N�^"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�R���X�g���N�^
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���O��ʂ̕ۑ�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Sub New()
    End Sub

    ''�����֐�(Function)-----------------------------------------------------------------------
#Region "mStr���O���e"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FmStr���O���e
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���O���e�̕ҏW�B
    ' ���@�l�@�F�G���[���b�Z�[�W�A�n�܂�n�_�ƍŏI�n�_�A�ɕҏW����B
    '---------------------------------------------------------------------------
#End Region
    Private Function mStr���O���e(ByVal ex As Exception) As String
        Dim strBuff() As String
        Dim str�ŏI As String = ""
        Dim str�ŏ� As String = ""
        Dim str���O���e As String = ""
        Dim i As Integer
        Dim j As Integer

        ''�X�^�b�N�ƃ��[�X��z��֕ۑ�
        strBuff = Split(ex.StackTrace, vbCrLf)

        ''�ŏI�G���[�n�_�̕ۑ�
        For i = LBound(strBuff) To UBound(strBuff)
            ''���s���͂���
            strBuff(i) = strBuff(i).Replace(vbCrLf, "")
            ''�o�^�ł��Ȃ������̕ϊ�
            strBuff(i) = strBuff(i).Replace("&", "")

            ''��͂ӂ��܂Ȃ�
            If strBuff(i) Is Nothing Then

            ElseIf strBuff(i).Trim = "" Then

                ''�v���W�F�N�g�̖��O��Ԃ̃X�^�b�N�g���[�X�̂�
            ElseIf InStr(strBuff(i), Application.ProductName & ".") = 0 Then

            Else
                str�ŏI = strBuff(i).Trim
                Exit For
            End If
        Next

        ''�ŏ��̃G���[�n�_�̕ۑ�
        For j = UBound(strBuff) To i Step -1
            ''���s���͂���
            strBuff(j) = strBuff(j).Replace(vbCrLf, "")
            ''�o�^�ł��Ȃ������̕ϊ�
            strBuff(j) = strBuff(j).Replace("&", "")

            ''��͂ӂ��܂Ȃ�
            If strBuff(j) Is Nothing Then

            ElseIf strBuff(j).Trim = "" Then

                ''�v���W�F�N�g�̖��O��Ԃ̃X�^�b�N�g���[�X�̂�
            ElseIf InStr(strBuff(j), Application.ProductName & ".") = 0 Then

            Else
                If j <> i Then
                    str�ŏ� = strBuff(j).Trim
                End If
                Exit For
            End If
        Next

        ''���O���e�ҏW
        If str�ŏ� <> "" Then
            'Chr(10)�ŉ��s
            str���O���e = ex.Message.Replace(Chr(10), "").Trim & Chr(10) & str�ŏI & Chr(10) & str�ŏ�
        Else
            str���O���e = ex.Message.Replace(Chr(10), "") & Chr(10) & str�ŏI
        End If

        ''���s�ϊ�
        str���O���e = str���O���e.Replace(vbCrLf, "")

        ''�V���O���ϊ�
        str���O���e = str���O���e.Replace("'", "''")

        Return str���O���e
    End Function

    ''�O���֐�(Sub)----------------------------------------------------------------------------
#Region "�G���[�������̃G���[�\���ƃ��O�o�^"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FgSubErr
    ' �߂�l�@�F
    ' ���@���@�Fexception
    ' �@�\�����F�G���[�������̃G���[�\���ƃ��O�o�^
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubErr(ByVal ex As Exception, ByVal Method_Name As String)
        Dim strMsg As String

        strMsg = ex.ToString
        ''���O�o�^
        Call Me.gSub�V�X�e�����O�o�^(Method_Name & " " & Me.mStr���O���e(ex), True)

        Call MessageBox.Show(strMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    ''���O�o�^------------------------------------------------------------------------------------------
    'Public Sub gSub���샍�O�o�^(ByVal str���O���e As String, ByVal blnTrans As Boolean)
    '    Try
    '        If MFile.gStrParameterStr("���샍�O", "1") = MConst.STRFLGOFF Then
    '            Exit Sub
    '        End If

    '        Dim claSQL As New CSql
    '        With claSQL
    '            .gSubClearSQL()
    '            .pSQLTYPE = CSql.SQL_TYPE.SQL_INSERT
    '            .pStrTable = "DC���샍�O�Ǘ�"
    '            .gSubColumnValue("���OID", "SQ���샍�O�o�^��.NEXTVAL", False)
    '            .gSubColumnValue("�����[��", MMain.gstrID, True)
    '            .gSubColumnValue("���O���e", str���O���e, True)
    '            If MMain.gstr���HNO.Trim <> "" Then
    '                .gSubColumnValue("���HNO", MMain.gstr���HNO, True)
    '            End If
    '            If MMain.gstr�q��.Trim <> "" Then
    '                .gSubColumnValue("�q��", MMain.gstr�q��, True)
    '            End If
    '            If MMain.gstr�Z�b�gNO.Trim <> "" Then
    '                .gSubColumnValue("�Z�b�gNO", MMain.gstr�Z�b�gNO, True)
    '            End If
    '            If MMain.gstr�J�b�gNO.Trim <> "" Then
    '                .gSubColumnValue("�J�b�gNO", MMain.gstr�J�b�gNO, True)
    '            End If
    '            .gSubColumnValue("���O���", "0", True) '�A�v��=0 PKG=1 
    '            Call MMain.gclaODP.gBlnExeCute(Me.GetType().Name & ".vb:" & System.Reflection.MethodBase.GetCurrentMethod.Name,.gStrSQL, blnTrans)
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Sub gSub�V�X�e�����O�o�^(ByVal str���O���e As String, ByVal blnTrans As Boolean)
        Try
            If MFile.gStrParameterStr("�V�X�e�����O", "1") = MConst.STRFLGOFF Then
                Exit Sub
            End If

            Dim claSQL As New CSql
            With claSQL
                .gSubClearSQL()
                .pSQLTYPE = CSql.SQL_TYPE.SQL_INSERT
                .pStrTable = "DC�V�X�e�����O�Ǘ�"
                .gSubColumnValue("���OID", "SQ�V�X�e�����O�o�^��.NEXTVAL", False)
                .gSubColumnValue("�����[��", MMain.gstrID, True)

                ''���s����Εϊ�
                str���O���e = str���O���e.Replace(vbCrLf, Chr(10))

                ''�V���O������Εϊ�
                str���O���e = str���O���e.Replace("'", "''")

                ''�ő働�O���e�𒴂���Ƃ�
                If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(str���O���e) > 3800 Then
                    .gSubColumnValue("���O���e", "SUBSTRB('" & str���O���e & "',1,3800)", False, 0, False)
                Else
                    .gSubColumnValue("���O���e", str���O���e, True)
                End If

                If MMain.gstr���HNO.Trim <> "" Then
                    .gSubColumnValue("���HNO", MMain.gstr���HNO, True)
                End If
                If MMain.gstr�q��.Trim <> "" Then
                    .gSubColumnValue("�q��", MMain.gstr�q��, True)
                End If
                If MMain.gstr�Z�b�gNO.Trim <> "" Then
                    .gSubColumnValue("�Z�b�gNO", MMain.gstr�Z�b�gNO, True)
                End If
                If MMain.gstr�J�b�gNO.Trim <> "" Then
                    .gSubColumnValue("�J�b�gNO", MMain.gstr�J�b�gNO, True)
                End If
                .gSubColumnValue("���O���", "0", True) '�A�v��=0 PKG=1 
                Call MMain.gclaODP.gBlnExeCute(Me.GetType().Name & ".vb:" & System.Reflection.MethodBase.GetCurrentMethod.Name, .gStrSQL, blnTrans)
            End With
        Catch ex As Exception
            Try
                Dim claSQL As New CSql
                With claSQL
                    .gSubClearSQL()
                    .pSQLTYPE = CSql.SQL_TYPE.SQL_INSERT
                    .pStrTable = "DC�V�X�e�����O�Ǘ�"
                    .gSubColumnValue("���OID", "SQ�V�X�e�����O�o�^��.NEXTVAL", False)
                    .gSubColumnValue("�����[��", MMain.gstrID, True)

                    .gSubColumnValue("���O���e", "err", True)

                    If MMain.gstr���HNO.Trim <> "" Then
                        .gSubColumnValue("���HNO", MMain.gstr���HNO, True)
                    End If
                    If MMain.gstr�q��.Trim <> "" Then
                        .gSubColumnValue("�q��", MMain.gstr�q��, True)
                    End If
                    If MMain.gstr�Z�b�gNO.Trim <> "" Then
                        .gSubColumnValue("�Z�b�gNO", MMain.gstr�Z�b�gNO, True)
                    End If
                    If MMain.gstr�J�b�gNO.Trim <> "" Then
                        .gSubColumnValue("�J�b�gNO", MMain.gstr�J�b�gNO, True)
                    End If
                    .gSubColumnValue("���O���", "0", True) '�A�v��=0 PKG=1 
                    Call MMain.gclaODP.gBlnExeCute(Me.GetType().Name & ".vb:" & System.Reflection.MethodBase.GetCurrentMethod.Name, .gStrSQL, blnTrans)
                End With

            Catch ex2 As Exception

            End Try
        End Try
    End Sub

End Class
