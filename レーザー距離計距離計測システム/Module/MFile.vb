'*******************************************************************************
' @(h)  MFile.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  �t�@�C������֘A�֐�
'*******************************************************************************
Imports System.IO
Imports System.Windows.Forms

Module MFile

#Region "�ݒ�t�@�C���f�[�^�Ǎ��i������f�[�^�j"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�ݒ�t�@�C���f�[�^�Ǎ��i������f�[�^�j
    ' ���@���@�FstrKeyName      �L�[��
    ' �@�@�@�@�@strDefault      �f�t�H���g�l
    ' �߂�l�@�FstrParam        �擾�p�����[�^
    ' �@�\�����F�ݒ�t�@�C�����當����f�[�^��ǂݍ��ށB
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Function gStrParameterStr(ByVal strKeyName As String, Optional ByVal strDefault As String = "") As String
        Dim strParm As String
        Try
            Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader

            strParm = CType(configurationAppSettings.GetValue(strKeyName, GetType(System.String)), String)
            ''�擾�ł��Ȃ����̓f�t�H���g��Ԃ�
        Catch exOpe As InvalidOperationException
            strParm = strDefault
        End Try

        Return strParm
    End Function

#Region "�t�@�C���ǂݍ���"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FCSV�o��
    ' ���@���@�FobjCollection �R���N�V����
    ' �߂�l�@�F
    ' �@�\�����F�t�@�C�����J�����e��1�s�ÂR���N�V�����Ɋi�[���܂�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Sub iSubFileRead(ByRef objCollection As Collection)
        Dim diaFile As New OpenFileDialog

        ''�t�@�C���_�C�A���O
        diaFile.Filter = "csv files (*.csv)|*.csv"
        If diaFile.ShowDialog() = DialogResult.OK Then
            Call Application.DoEvents()

            Dim sr As New StreamReader(diaFile.FileName, System.Text.Encoding.GetEncoding(932))
            Try
                '���e����s���ǂݍ���
                While sr.Peek() > -1
                    objCollection.Add(sr.ReadLine())
                End While
            Finally
                '����
                sr.Close()
            End Try
        End If
    End Sub

#Region "�t�@�C�����擾"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�t�@�C�����擾
    ' ���@���@�FstrFilter       �t�B���^�ݒ蕶����
    '           strFileName     �t�@�C�����f�t�H���g�l
    ' �߂�l�@�FblnRslt         ��������
    '           strFileName     �t�@�C����
    ' �@�\�����F�t�@�C�����w��_�C�A���O��\�����A�t�@�C������Ԃ��B
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Function gBln�t�@�C�����擾(ByRef strFileName As String, ByVal strDirectory As String, ByVal strFilter As String) As Boolean
        Dim objFileDialog As New OpenFileDialog

        With objFileDialog
            ''�t�@�C���t�B���^�ݒ�
            .Filter = strFilter
            ''�����t�@�C�����ݒ�
            .FileName = strFileName
            ''�����f�B���N�g���ݒ�
            If strDirectory.Length = 0 Then strDirectory = Application.StartupPath
            .InitialDirectory = strDirectory

            ''�t�@�C���w��_�C�A���O�\��
            If .ShowDialog() = DialogResult.OK Then
                Call Application.DoEvents()

                ''�w��t�@�C�����i�[
                strFileName = .FileName

                Return True
            End If
        End With
        objFileDialog = Nothing

    End Function

#Region "Log�t�@�C���̈�s������"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FLog�t�@�C���̈�s�����ݏ���
    ' ���@���@�F�����ݕ�����
    ' �߂�l�@�F����
    ' �@�\�����FLog�t�@�C���̈�s�����ݏ���
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Function gBlnLogFileLineWrite(ByVal strPram As String, ByVal strPath As String, ByVal blnAdd As Boolean) As Boolean

        If strPram Is Nothing Then
            Exit Function
        End If

        ''�t�@�C�����㏑�����AShift JIS�ŏ�������
        Dim sysLine As System.IO.StreamWriter

        Try

            ''�t�@�C�����㏑�����AShift JIS�ŏ�������
            sysLine = New System.IO.StreamWriter(strPath, blnAdd, System.Text.Encoding.GetEncoding(932))

            ''������
            sysLine.WriteLine(strPram)
            Return True
        Finally
            If Not sysLine Is Nothing Then
                sysLine.Close()
            End If
        End Try

    End Function

#Region "Log�t�@�C���̈�s�Ǎ���"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FLog�t�@�C���̈�s�����ݏ���
    ' ���@���@�F�����ݕ�����
    ' �߂�l�@�F����
    ' �@�\�����FLog�t�@�C���̈�s�����ݏ���
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Function gStrLogFileLineRead(ByVal strPath As String) As String

        ''�t�@�C�����㏑�����AShift JIS�ŏ�������
        Dim sysLine As System.IO.StreamReader

        Try

            ''�t�@�C�����㏑�����AShift JIS�ŏ�������
            sysLine = New System.IO.StreamReader(strPath, System.Text.Encoding.GetEncoding(932))

            ''�Ǎ��݁i���ʂ�Ԃ��j
            Return CType(sysLine.ReadLine(), String)

        Finally
            If Not sysLine Is Nothing Then
                sysLine.Close()
            End If
        End Try

    End Function

#Region "Log�t�@�C���ǂݍ���"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FCSV�o��
    ' ���@���@�FobjCollection �R���N�V����
    ' �߂�l�@�F
    ' �@�\�����F�t�@�C�����J�����e��1�s�ÂR���N�V�����Ɋi�[���܂�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubFileRead(ByRef objCollection As Collection, ByVal strPath As String)

        ''�t�@�C���_�C�A���O

        Dim key As Integer = 0
        Dim sr As New StreamReader(strPath, System.Text.Encoding.GetEncoding(932))
        Try
            '���e����s���ǂݍ���
            While sr.Peek() > -1
                'objCollection.Add(sr.ReadLine(), CStr(key))
                'If Not sr.ReadLine().Trim = "" Then
                objCollection.Add(sr.ReadLine())
                key += 1
                'End If

            End While
        Finally
            '����
            sr.Close()
        End Try

    End Sub

#Region "�t�@�C���̌���"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FLog�t�@�C���̈�s�����ݏ���
    ' ���@���@�F�����ݕ�����
    ' �߂�l�@�F����
    ' �@�\�����FLog�t�@�C���̈�s�����ݏ���
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Function gBlnFileEixstChk(ByVal strPath As String) As Boolean

        '�t�@�C���̑��݂��m�F����
        '���݂����True��Ԃ� 
        If File.Exists(strPath) = True Then
            Return True
        Else
            Return False
        End If

    End Function

#Region "�t�@�C���̎擾"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FLog�t�@�C���̈�s�����ݏ���
    ' ���@���@�F�����ݕ�����
    ' �߂�l�@�F����
    ' �@�\�����FLog�t�@�C���̈�s�����ݏ���
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Function gStrFileGet(ByVal strPath As String) As String()
        Dim files As String() = System.IO.Directory.GetFiles(strPath, "*", SearchOption.AllDirectories)

        Return files
    End Function

End Module
