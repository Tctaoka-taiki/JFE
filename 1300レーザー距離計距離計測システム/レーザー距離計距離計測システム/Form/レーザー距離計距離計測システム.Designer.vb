<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class レーザー距離計距離計測システム
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Lbl_CapX軸 = New System.Windows.Forms.Label
        Me.Lbl_DataX軸 = New System.Windows.Forms.Label
        Me.Lbl_CapY軸 = New System.Windows.Forms.Label
        Me.Lbl_DataY軸 = New System.Windows.Forms.Label
        Me.Lbl_CapZ軸 = New System.Windows.Forms.Label
        Me.Lbl_DataZ軸 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Lbltest_TNG = New System.Windows.Forms.Label
        Me.Lbltest_POW = New System.Windows.Forms.Label
        Me.Lbltest_C_TNG = New System.Windows.Forms.Label
        Me.Lbltest_C_POW = New System.Windows.Forms.Label
        Me.Lbltest_P_TNG = New System.Windows.Forms.Label
        Me.Lbltest_P_POW = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lbl_Data計測時刻 = New System.Windows.Forms.Label
        Me.lblDataトングSTS = New System.Windows.Forms.Label
        Me.lbl_Capファイル名 = New System.Windows.Forms.Label
        Me.lblCap計測履歴 = New System.Windows.Forms.Label
        Me.lbl_Cap計測時刻 = New System.Windows.Forms.Label
        Me.txt計測履歴 = New System.Windows.Forms.TextBox
        Me.lbl_Dataファイル名 = New System.Windows.Forms.Label
        Me.lblCapトングSTS = New System.Windows.Forms.Label
        Me.btn終了 = New System.Windows.Forms.Button
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.SLblシステム状態 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Slbl現在時刻 = New System.Windows.Forms.ToolStripStatusLabel
        Me.txt機器状況 = New System.Windows.Forms.TextBox
        Me.btn機器チェック = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblD入力トングSTS = New System.Windows.Forms.Label
        Me.lblD入力電源 = New System.Windows.Forms.Label
        Me.lblDataRKZ = New System.Windows.Forms.Label
        Me.lblDataRKY = New System.Windows.Forms.Label
        Me.lblDataRKX = New System.Windows.Forms.Label
        Me.lblDataX軸CHK = New System.Windows.Forms.Label
        Me.lblData入力トングSTS = New System.Windows.Forms.Label
        Me.lblCapX軸CHK = New System.Windows.Forms.Label
        Me.lblData入力電源 = New System.Windows.Forms.Label
        Me.lblCapY軸CHK = New System.Windows.Forms.Label
        Me.lblDataZ軸CHK = New System.Windows.Forms.Label
        Me.lblCapZ軸CHK = New System.Windows.Forms.Label
        Me.lblCapInCHK = New System.Windows.Forms.Label
        Me.lblDataY軸CHK = New System.Windows.Forms.Label
        Me.Grp機器接続 = New System.Windows.Forms.GroupBox
        Me.lbl接続CHKX = New System.Windows.Forms.Label
        Me.LblCOMCHKD1 = New System.Windows.Forms.Label
        Me.lbl接続CHKD1 = New System.Windows.Forms.Label
        Me.LblCOMCHKZ = New System.Windows.Forms.Label
        Me.LblCOMCHKY = New System.Windows.Forms.Label
        Me.lbl接続CHKZ = New System.Windows.Forms.Label
        Me.LblCOMCHKX = New System.Windows.Forms.Label
        Me.lbl接続CHKY = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl接続CHKST1_Y = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lbl接続CHKST1_X = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbl接続CHKST2_Z = New System.Windows.Forms.Label
        Me.lbl接続CHKST2_D1 = New System.Windows.Forms.Label
        Me.lblCaption = New System.Windows.Forms.Label
        Me.tmrNow = New System.Windows.Forms.Timer(Me.components)
        Me.tmr7 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Grp機器接続.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_CapX軸
        '
        Me.Lbl_CapX軸.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_CapX軸.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_CapX軸.Location = New System.Drawing.Point(314, 61)
        Me.Lbl_CapX軸.Name = "Lbl_CapX軸"
        Me.Lbl_CapX軸.Size = New System.Drawing.Size(40, 20)
        Me.Lbl_CapX軸.TabIndex = 0
        Me.Lbl_CapX軸.Text = "X軸"
        Me.Lbl_CapX軸.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_DataX軸
        '
        Me.Lbl_DataX軸.BackColor = System.Drawing.SystemColors.Control
        Me.Lbl_DataX軸.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_DataX軸.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_DataX軸.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lbl_DataX軸.Location = New System.Drawing.Point(360, 61)
        Me.Lbl_DataX軸.Name = "Lbl_DataX軸"
        Me.Lbl_DataX軸.Size = New System.Drawing.Size(70, 20)
        Me.Lbl_DataX軸.TabIndex = 1
        Me.Lbl_DataX軸.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_CapY軸
        '
        Me.Lbl_CapY軸.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_CapY軸.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_CapY軸.Location = New System.Drawing.Point(433, 61)
        Me.Lbl_CapY軸.Name = "Lbl_CapY軸"
        Me.Lbl_CapY軸.Size = New System.Drawing.Size(40, 20)
        Me.Lbl_CapY軸.TabIndex = 0
        Me.Lbl_CapY軸.Text = "Y軸"
        Me.Lbl_CapY軸.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_DataY軸
        '
        Me.Lbl_DataY軸.BackColor = System.Drawing.SystemColors.Control
        Me.Lbl_DataY軸.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_DataY軸.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_DataY軸.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lbl_DataY軸.Location = New System.Drawing.Point(479, 61)
        Me.Lbl_DataY軸.Name = "Lbl_DataY軸"
        Me.Lbl_DataY軸.Size = New System.Drawing.Size(70, 20)
        Me.Lbl_DataY軸.TabIndex = 1
        Me.Lbl_DataY軸.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_CapZ軸
        '
        Me.Lbl_CapZ軸.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_CapZ軸.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_CapZ軸.Location = New System.Drawing.Point(553, 61)
        Me.Lbl_CapZ軸.Name = "Lbl_CapZ軸"
        Me.Lbl_CapZ軸.Size = New System.Drawing.Size(40, 20)
        Me.Lbl_CapZ軸.TabIndex = 0
        Me.Lbl_CapZ軸.Text = "Z軸"
        Me.Lbl_CapZ軸.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_DataZ軸
        '
        Me.Lbl_DataZ軸.BackColor = System.Drawing.SystemColors.Control
        Me.Lbl_DataZ軸.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_DataZ軸.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl_DataZ軸.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lbl_DataZ軸.Location = New System.Drawing.Point(599, 61)
        Me.Lbl_DataZ軸.Name = "Lbl_DataZ軸"
        Me.Lbl_DataZ軸.Size = New System.Drawing.Size(70, 20)
        Me.Lbl_DataZ軸.TabIndex = 1
        Me.Lbl_DataZ軸.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.lbl_Data計測時刻)
        Me.GroupBox2.Controls.Add(Me.lblDataトングSTS)
        Me.GroupBox2.Controls.Add(Me.Lbl_DataZ軸)
        Me.GroupBox2.Controls.Add(Me.lbl_Capファイル名)
        Me.GroupBox2.Controls.Add(Me.lblCap計測履歴)
        Me.GroupBox2.Controls.Add(Me.lbl_Cap計測時刻)
        Me.GroupBox2.Controls.Add(Me.txt計測履歴)
        Me.GroupBox2.Controls.Add(Me.Lbl_CapX軸)
        Me.GroupBox2.Controls.Add(Me.Lbl_DataY軸)
        Me.GroupBox2.Controls.Add(Me.Lbl_CapY軸)
        Me.GroupBox2.Controls.Add(Me.lbl_Dataファイル名)
        Me.GroupBox2.Controls.Add(Me.Lbl_DataX軸)
        Me.GroupBox2.Controls.Add(Me.lblCapトングSTS)
        Me.GroupBox2.Controls.Add(Me.Lbl_CapZ軸)
        Me.GroupBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(992, 234)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "計測状況"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Lbltest_TNG)
        Me.GroupBox4.Controls.Add(Me.Lbltest_POW)
        Me.GroupBox4.Controls.Add(Me.Lbltest_C_TNG)
        Me.GroupBox4.Controls.Add(Me.Lbltest_C_POW)
        Me.GroupBox4.Controls.Add(Me.Lbltest_P_TNG)
        Me.GroupBox4.Controls.Add(Me.Lbltest_P_POW)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Location = New System.Drawing.Point(811, 36)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(168, 179)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "DI監視（TEST）"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(49, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "scrolltest"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(35, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 20)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "前"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(55, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 20)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "今"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbltest_TNG
        '
        Me.Lbltest_TNG.BackColor = System.Drawing.SystemColors.Control
        Me.Lbltest_TNG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbltest_TNG.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbltest_TNG.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lbltest_TNG.Location = New System.Drawing.Point(122, 98)
        Me.Lbltest_TNG.Name = "Lbltest_TNG"
        Me.Lbltest_TNG.Size = New System.Drawing.Size(30, 20)
        Me.Lbltest_TNG.TabIndex = 2
        Me.Lbltest_TNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbltest_POW
        '
        Me.Lbltest_POW.BackColor = System.Drawing.SystemColors.Control
        Me.Lbltest_POW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbltest_POW.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbltest_POW.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lbltest_POW.Location = New System.Drawing.Point(122, 58)
        Me.Lbltest_POW.Name = "Lbltest_POW"
        Me.Lbltest_POW.Size = New System.Drawing.Size(30, 20)
        Me.Lbltest_POW.TabIndex = 2
        Me.Lbltest_POW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbltest_C_TNG
        '
        Me.Lbltest_C_TNG.BackColor = System.Drawing.SystemColors.Control
        Me.Lbltest_C_TNG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbltest_C_TNG.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbltest_C_TNG.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lbltest_C_TNG.Location = New System.Drawing.Point(86, 98)
        Me.Lbltest_C_TNG.Name = "Lbltest_C_TNG"
        Me.Lbltest_C_TNG.Size = New System.Drawing.Size(30, 20)
        Me.Lbltest_C_TNG.TabIndex = 2
        Me.Lbltest_C_TNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbltest_C_POW
        '
        Me.Lbltest_C_POW.BackColor = System.Drawing.SystemColors.Control
        Me.Lbltest_C_POW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbltest_C_POW.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbltest_C_POW.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lbltest_C_POW.Location = New System.Drawing.Point(86, 58)
        Me.Lbltest_C_POW.Name = "Lbltest_C_POW"
        Me.Lbltest_C_POW.Size = New System.Drawing.Size(30, 20)
        Me.Lbltest_C_POW.TabIndex = 2
        Me.Lbltest_C_POW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbltest_P_TNG
        '
        Me.Lbltest_P_TNG.BackColor = System.Drawing.SystemColors.Control
        Me.Lbltest_P_TNG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbltest_P_TNG.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbltest_P_TNG.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lbltest_P_TNG.Location = New System.Drawing.Point(50, 98)
        Me.Lbltest_P_TNG.Name = "Lbltest_P_TNG"
        Me.Lbltest_P_TNG.Size = New System.Drawing.Size(30, 20)
        Me.Lbltest_P_TNG.TabIndex = 2
        Me.Lbltest_P_TNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbltest_P_POW
        '
        Me.Lbltest_P_POW.BackColor = System.Drawing.SystemColors.Control
        Me.Lbltest_P_POW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbltest_P_POW.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbltest_P_POW.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Lbltest_P_POW.Location = New System.Drawing.Point(50, 58)
        Me.Lbltest_P_POW.Name = "Lbltest_P_POW"
        Me.Lbltest_P_POW.Size = New System.Drawing.Size(30, 20)
        Me.Lbltest_P_POW.TabIndex = 2
        Me.Lbltest_P_POW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(9, 98)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(46, 20)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "TNG"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(9, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 20)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "POW"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(101, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 20)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "変化"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Data計測時刻
        '
        Me.lbl_Data計測時刻.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Data計測時刻.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Data計測時刻.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_Data計測時刻.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_Data計測時刻.Location = New System.Drawing.Point(108, 36)
        Me.lbl_Data計測時刻.Name = "lbl_Data計測時刻"
        Me.lbl_Data計測時刻.Size = New System.Drawing.Size(197, 20)
        Me.lbl_Data計測時刻.TabIndex = 1
        Me.lbl_Data計測時刻.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDataトングSTS
        '
        Me.lblDataトングSTS.BackColor = System.Drawing.SystemColors.Control
        Me.lblDataトングSTS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDataトングSTS.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDataトングSTS.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDataトングSTS.Location = New System.Drawing.Point(761, 61)
        Me.lblDataトングSTS.Name = "lblDataトングSTS"
        Me.lblDataトングSTS.Size = New System.Drawing.Size(38, 20)
        Me.lblDataトングSTS.TabIndex = 1
        Me.lblDataトングSTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Capファイル名
        '
        Me.lbl_Capファイル名.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_Capファイル名.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Capファイル名.Location = New System.Drawing.Point(5, 61)
        Me.lbl_Capファイル名.Name = "lbl_Capファイル名"
        Me.lbl_Capファイル名.Size = New System.Drawing.Size(97, 20)
        Me.lbl_Capファイル名.TabIndex = 0
        Me.lbl_Capファイル名.Text = "ファイル名"
        Me.lbl_Capファイル名.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCap計測履歴
        '
        Me.lblCap計測履歴.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCap計測履歴.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCap計測履歴.Location = New System.Drawing.Point(22, 96)
        Me.lblCap計測履歴.Name = "lblCap計測履歴"
        Me.lblCap計測履歴.Size = New System.Drawing.Size(80, 20)
        Me.lblCap計測履歴.TabIndex = 0
        Me.lblCap計測履歴.Text = "計測履歴"
        Me.lblCap計測履歴.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Cap計測時刻
        '
        Me.lbl_Cap計測時刻.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_Cap計測時刻.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Cap計測時刻.Location = New System.Drawing.Point(22, 36)
        Me.lbl_Cap計測時刻.Name = "lbl_Cap計測時刻"
        Me.lbl_Cap計測時刻.Size = New System.Drawing.Size(80, 20)
        Me.lbl_Cap計測時刻.TabIndex = 0
        Me.lbl_Cap計測時刻.Text = "計測時刻"
        Me.lbl_Cap計測時刻.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt計測履歴
        '
        Me.txt計測履歴.BackColor = System.Drawing.SystemColors.Window
        Me.txt計測履歴.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt計測履歴.Location = New System.Drawing.Point(108, 97)
        Me.txt計測履歴.Multiline = True
        Me.txt計測履歴.Name = "txt計測履歴"
        Me.txt計測履歴.ReadOnly = True
        Me.txt計測履歴.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt計測履歴.Size = New System.Drawing.Size(691, 118)
        Me.txt計測履歴.TabIndex = 3
        Me.txt計測履歴.TabStop = False
        '
        'lbl_Dataファイル名
        '
        Me.lbl_Dataファイル名.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Dataファイル名.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Dataファイル名.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_Dataファイル名.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_Dataファイル名.Location = New System.Drawing.Point(108, 61)
        Me.lbl_Dataファイル名.Name = "lbl_Dataファイル名"
        Me.lbl_Dataファイル名.Size = New System.Drawing.Size(197, 20)
        Me.lbl_Dataファイル名.TabIndex = 1
        Me.lbl_Dataファイル名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCapトングSTS
        '
        Me.lblCapトングSTS.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCapトングSTS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCapトングSTS.Location = New System.Drawing.Point(668, 61)
        Me.lblCapトングSTS.Name = "lblCapトングSTS"
        Me.lblCapトングSTS.Size = New System.Drawing.Size(87, 20)
        Me.lblCapトングSTS.TabIndex = 0
        Me.lblCapトングSTS.Text = "トング状態"
        Me.lblCapトングSTS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn終了
        '
        Me.btn終了.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn終了.Location = New System.Drawing.Point(928, 59)
        Me.btn終了.Name = "btn終了"
        Me.btn終了.Size = New System.Drawing.Size(76, 30)
        Me.btn終了.TabIndex = 6
        Me.btn終了.Text = "終了"
        Me.btn終了.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SLblシステム状態, Me.Slbl現在時刻})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 684)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip.Size = New System.Drawing.Size(1016, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'SLblシステム状態
        '
        Me.SLblシステム状態.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.SLblシステム状態.Name = "SLblシステム状態"
        Me.SLblシステム状態.Size = New System.Drawing.Size(53, 17)
        Me.SLblシステム状態.Text = "オンライン"
        '
        'Slbl現在時刻
        '
        Me.Slbl現在時刻.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.Slbl現在時刻.Name = "Slbl現在時刻"
        Me.Slbl現在時刻.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Slbl現在時刻.Size = New System.Drawing.Size(165, 17)
        Me.Slbl現在時刻.Text = "YYYY/MM/DD(DDD) HH:MI:SS"
        Me.Slbl現在時刻.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt機器状況
        '
        Me.txt機器状況.BackColor = System.Drawing.SystemColors.Window
        Me.txt機器状況.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt機器状況.Location = New System.Drawing.Point(25, 238)
        Me.txt機器状況.Multiline = True
        Me.txt機器状況.Name = "txt機器状況"
        Me.txt機器状況.ReadOnly = True
        Me.txt機器状況.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt機器状況.Size = New System.Drawing.Size(718, 77)
        Me.txt機器状況.TabIndex = 4
        Me.txt機器状況.TabStop = False
        Me.txt機器状況.Text = "すべての機器は正常に動作しています。"
        '
        'btn機器チェック
        '
        Me.btn機器チェック.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn機器チェック.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn機器チェック.Location = New System.Drawing.Point(835, 285)
        Me.btn機器チェック.Name = "btn機器チェック"
        Me.btn機器チェック.Size = New System.Drawing.Size(125, 30)
        Me.btn機器チェック.TabIndex = 2
        Me.btn機器チェック.Text = "機器チェック"
        Me.btn機器チェック.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Grp機器接続)
        Me.GroupBox1.Controls.Add(Me.btn機器チェック)
        Me.GroupBox1.Controls.Add(Me.txt機器状況)
        Me.GroupBox1.Controls.Add(Me.lbl接続CHKST1_Y)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lbl接続CHKST1_X)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lbl接続CHKST2_Z)
        Me.GroupBox1.Controls.Add(Me.lbl接続CHKST2_D1)
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 337)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(992, 329)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "機器状況"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblD入力トングSTS)
        Me.GroupBox3.Controls.Add(Me.lblD入力電源)
        Me.GroupBox3.Controls.Add(Me.lblDataRKZ)
        Me.GroupBox3.Controls.Add(Me.lblDataRKY)
        Me.GroupBox3.Controls.Add(Me.lblDataRKX)
        Me.GroupBox3.Controls.Add(Me.lblDataX軸CHK)
        Me.GroupBox3.Controls.Add(Me.lblData入力トングSTS)
        Me.GroupBox3.Controls.Add(Me.lblCapX軸CHK)
        Me.GroupBox3.Controls.Add(Me.lblData入力電源)
        Me.GroupBox3.Controls.Add(Me.lblCapY軸CHK)
        Me.GroupBox3.Controls.Add(Me.lblDataZ軸CHK)
        Me.GroupBox3.Controls.Add(Me.lblCapZ軸CHK)
        Me.GroupBox3.Controls.Add(Me.lblCapInCHK)
        Me.GroupBox3.Controls.Add(Me.lblDataY軸CHK)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(749, 27)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 186)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "データ"
        '
        'lblD入力トングSTS
        '
        Me.lblD入力トングSTS.BackColor = System.Drawing.SystemColors.Control
        Me.lblD入力トングSTS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblD入力トングSTS.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblD入力トングSTS.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblD入力トングSTS.Location = New System.Drawing.Point(50, 152)
        Me.lblD入力トングSTS.Name = "lblD入力トングSTS"
        Me.lblD入力トングSTS.Size = New System.Drawing.Size(50, 20)
        Me.lblD入力トングSTS.TabIndex = 6
        Me.lblD入力トングSTS.Text = "OK"
        Me.lblD入力トングSTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblD入力電源
        '
        Me.lblD入力電源.BackColor = System.Drawing.SystemColors.Control
        Me.lblD入力電源.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblD入力電源.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblD入力電源.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblD入力電源.Location = New System.Drawing.Point(50, 125)
        Me.lblD入力電源.Name = "lblD入力電源"
        Me.lblD入力電源.Size = New System.Drawing.Size(50, 20)
        Me.lblD入力電源.TabIndex = 6
        Me.lblD入力電源.Text = "OK"
        Me.lblD入力電源.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDataRKZ
        '
        Me.lblDataRKZ.BackColor = System.Drawing.SystemColors.Control
        Me.lblDataRKZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDataRKZ.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDataRKZ.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDataRKZ.Location = New System.Drawing.Point(50, 94)
        Me.lblDataRKZ.Name = "lblDataRKZ"
        Me.lblDataRKZ.Size = New System.Drawing.Size(50, 20)
        Me.lblDataRKZ.TabIndex = 6
        Me.lblDataRKZ.Text = "OK"
        Me.lblDataRKZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDataRKY
        '
        Me.lblDataRKY.BackColor = System.Drawing.SystemColors.Control
        Me.lblDataRKY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDataRKY.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDataRKY.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDataRKY.Location = New System.Drawing.Point(50, 61)
        Me.lblDataRKY.Name = "lblDataRKY"
        Me.lblDataRKY.Size = New System.Drawing.Size(50, 20)
        Me.lblDataRKY.TabIndex = 6
        Me.lblDataRKY.Text = "OK"
        Me.lblDataRKY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDataRKX
        '
        Me.lblDataRKX.BackColor = System.Drawing.SystemColors.Control
        Me.lblDataRKX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDataRKX.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDataRKX.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDataRKX.Location = New System.Drawing.Point(50, 28)
        Me.lblDataRKX.Name = "lblDataRKX"
        Me.lblDataRKX.Size = New System.Drawing.Size(50, 20)
        Me.lblDataRKX.TabIndex = 6
        Me.lblDataRKX.Text = "OK"
        Me.lblDataRKX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDataX軸CHK
        '
        Me.lblDataX軸CHK.BackColor = System.Drawing.SystemColors.Control
        Me.lblDataX軸CHK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDataX軸CHK.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDataX軸CHK.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDataX軸CHK.Location = New System.Drawing.Point(106, 28)
        Me.lblDataX軸CHK.Name = "lblDataX軸CHK"
        Me.lblDataX軸CHK.Size = New System.Drawing.Size(80, 20)
        Me.lblDataX軸CHK.TabIndex = 1
        Me.lblDataX軸CHK.Text = "999999"
        Me.lblDataX軸CHK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblData入力トングSTS
        '
        Me.lblData入力トングSTS.BackColor = System.Drawing.SystemColors.Control
        Me.lblData入力トングSTS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblData入力トングSTS.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblData入力トングSTS.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblData入力トングSTS.Location = New System.Drawing.Point(106, 152)
        Me.lblData入力トングSTS.Name = "lblData入力トングSTS"
        Me.lblData入力トングSTS.Size = New System.Drawing.Size(80, 20)
        Me.lblData入力トングSTS.TabIndex = 1
        Me.lblData入力トングSTS.Text = "トング開"
        Me.lblData入力トングSTS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCapX軸CHK
        '
        Me.lblCapX軸CHK.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCapX軸CHK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCapX軸CHK.Location = New System.Drawing.Point(7, 28)
        Me.lblCapX軸CHK.Name = "lblCapX軸CHK"
        Me.lblCapX軸CHK.Size = New System.Drawing.Size(40, 20)
        Me.lblCapX軸CHK.TabIndex = 0
        Me.lblCapX軸CHK.Text = "X軸"
        Me.lblCapX軸CHK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblData入力電源
        '
        Me.lblData入力電源.BackColor = System.Drawing.SystemColors.Control
        Me.lblData入力電源.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblData入力電源.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblData入力電源.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblData入力電源.Location = New System.Drawing.Point(106, 125)
        Me.lblData入力電源.Name = "lblData入力電源"
        Me.lblData入力電源.Size = New System.Drawing.Size(80, 20)
        Me.lblData入力電源.TabIndex = 1
        Me.lblData入力電源.Text = "電源ON"
        Me.lblData入力電源.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCapY軸CHK
        '
        Me.lblCapY軸CHK.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCapY軸CHK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCapY軸CHK.Location = New System.Drawing.Point(7, 61)
        Me.lblCapY軸CHK.Name = "lblCapY軸CHK"
        Me.lblCapY軸CHK.Size = New System.Drawing.Size(40, 20)
        Me.lblCapY軸CHK.TabIndex = 0
        Me.lblCapY軸CHK.Text = "Y軸"
        Me.lblCapY軸CHK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDataZ軸CHK
        '
        Me.lblDataZ軸CHK.BackColor = System.Drawing.SystemColors.Control
        Me.lblDataZ軸CHK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDataZ軸CHK.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDataZ軸CHK.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDataZ軸CHK.Location = New System.Drawing.Point(106, 94)
        Me.lblDataZ軸CHK.Name = "lblDataZ軸CHK"
        Me.lblDataZ軸CHK.Size = New System.Drawing.Size(80, 20)
        Me.lblDataZ軸CHK.TabIndex = 1
        Me.lblDataZ軸CHK.Text = "999999"
        Me.lblDataZ軸CHK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCapZ軸CHK
        '
        Me.lblCapZ軸CHK.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCapZ軸CHK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCapZ軸CHK.Location = New System.Drawing.Point(7, 94)
        Me.lblCapZ軸CHK.Name = "lblCapZ軸CHK"
        Me.lblCapZ軸CHK.Size = New System.Drawing.Size(40, 20)
        Me.lblCapZ軸CHK.TabIndex = 0
        Me.lblCapZ軸CHK.Text = "Z軸"
        Me.lblCapZ軸CHK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCapInCHK
        '
        Me.lblCapInCHK.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCapInCHK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCapInCHK.Location = New System.Drawing.Point(6, 138)
        Me.lblCapInCHK.Name = "lblCapInCHK"
        Me.lblCapInCHK.Size = New System.Drawing.Size(42, 20)
        Me.lblCapInCHK.TabIndex = 0
        Me.lblCapInCHK.Text = "信号"
        Me.lblCapInCHK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDataY軸CHK
        '
        Me.lblDataY軸CHK.BackColor = System.Drawing.SystemColors.Control
        Me.lblDataY軸CHK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDataY軸CHK.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDataY軸CHK.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDataY軸CHK.Location = New System.Drawing.Point(106, 61)
        Me.lblDataY軸CHK.Name = "lblDataY軸CHK"
        Me.lblDataY軸CHK.Size = New System.Drawing.Size(80, 20)
        Me.lblDataY軸CHK.TabIndex = 1
        Me.lblDataY軸CHK.Text = "999999"
        Me.lblDataY軸CHK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Grp機器接続
        '
        Me.Grp機器接続.BackColor = System.Drawing.SystemColors.Control
        Me.Grp機器接続.Controls.Add(Me.lbl接続CHKX)
        Me.Grp機器接続.Controls.Add(Me.LblCOMCHKD1)
        Me.Grp機器接続.Controls.Add(Me.lbl接続CHKD1)
        Me.Grp機器接続.Controls.Add(Me.LblCOMCHKZ)
        Me.Grp機器接続.Controls.Add(Me.LblCOMCHKY)
        Me.Grp機器接続.Controls.Add(Me.lbl接続CHKZ)
        Me.Grp機器接続.Controls.Add(Me.LblCOMCHKX)
        Me.Grp機器接続.Controls.Add(Me.lbl接続CHKY)
        Me.Grp機器接続.Controls.Add(Me.Label16)
        Me.Grp機器接続.Controls.Add(Me.Label13)
        Me.Grp機器接続.Controls.Add(Me.Label10)
        Me.Grp機器接続.Controls.Add(Me.Label6)
        Me.Grp機器接続.Controls.Add(Me.Label15)
        Me.Grp機器接続.Controls.Add(Me.Label11)
        Me.Grp機器接続.Controls.Add(Me.Label7)
        Me.Grp機器接続.Controls.Add(Me.Label5)
        Me.Grp機器接続.Controls.Add(Me.Label12)
        Me.Grp機器接続.Controls.Add(Me.Label8)
        Me.Grp機器接続.Controls.Add(Me.Label3)
        Me.Grp機器接続.Controls.Add(Me.Label1)
        Me.Grp機器接続.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Grp機器接続.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Grp機器接続.Location = New System.Drawing.Point(25, 27)
        Me.Grp機器接続.Name = "Grp機器接続"
        Me.Grp機器接続.Size = New System.Drawing.Size(718, 186)
        Me.Grp機器接続.TabIndex = 6
        Me.Grp機器接続.TabStop = False
        Me.Grp機器接続.Text = "接続"
        '
        'lbl接続CHKX
        '
        Me.lbl接続CHKX.BackColor = System.Drawing.SystemColors.Control
        Me.lbl接続CHKX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl接続CHKX.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl接続CHKX.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl接続CHKX.Location = New System.Drawing.Point(165, 28)
        Me.lbl接続CHKX.Name = "lbl接続CHKX"
        Me.lbl接続CHKX.Size = New System.Drawing.Size(50, 20)
        Me.lbl接続CHKX.TabIndex = 5
        Me.lbl接続CHKX.Text = "OK"
        Me.lbl接続CHKX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCOMCHKD1
        '
        Me.LblCOMCHKD1.BackColor = System.Drawing.SystemColors.Control
        Me.LblCOMCHKD1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCOMCHKD1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblCOMCHKD1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LblCOMCHKD1.Location = New System.Drawing.Point(447, 138)
        Me.LblCOMCHKD1.Name = "LblCOMCHKD1"
        Me.LblCOMCHKD1.Size = New System.Drawing.Size(50, 20)
        Me.LblCOMCHKD1.TabIndex = 5
        Me.LblCOMCHKD1.Text = "OK"
        Me.LblCOMCHKD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl接続CHKD1
        '
        Me.lbl接続CHKD1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl接続CHKD1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl接続CHKD1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl接続CHKD1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl接続CHKD1.Location = New System.Drawing.Point(165, 138)
        Me.lbl接続CHKD1.Name = "lbl接続CHKD1"
        Me.lbl接続CHKD1.Size = New System.Drawing.Size(50, 20)
        Me.lbl接続CHKD1.TabIndex = 5
        Me.lbl接続CHKD1.Text = "OK"
        Me.lbl接続CHKD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCOMCHKZ
        '
        Me.LblCOMCHKZ.BackColor = System.Drawing.SystemColors.Control
        Me.LblCOMCHKZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCOMCHKZ.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblCOMCHKZ.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LblCOMCHKZ.Location = New System.Drawing.Point(447, 94)
        Me.LblCOMCHKZ.Name = "LblCOMCHKZ"
        Me.LblCOMCHKZ.Size = New System.Drawing.Size(50, 20)
        Me.LblCOMCHKZ.TabIndex = 5
        Me.LblCOMCHKZ.Text = "OK"
        Me.LblCOMCHKZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCOMCHKY
        '
        Me.LblCOMCHKY.BackColor = System.Drawing.SystemColors.Control
        Me.LblCOMCHKY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCOMCHKY.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblCOMCHKY.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LblCOMCHKY.Location = New System.Drawing.Point(447, 61)
        Me.LblCOMCHKY.Name = "LblCOMCHKY"
        Me.LblCOMCHKY.Size = New System.Drawing.Size(50, 20)
        Me.LblCOMCHKY.TabIndex = 5
        Me.LblCOMCHKY.Text = "OK"
        Me.LblCOMCHKY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl接続CHKZ
        '
        Me.lbl接続CHKZ.BackColor = System.Drawing.SystemColors.Control
        Me.lbl接続CHKZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl接続CHKZ.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl接続CHKZ.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl接続CHKZ.Location = New System.Drawing.Point(165, 94)
        Me.lbl接続CHKZ.Name = "lbl接続CHKZ"
        Me.lbl接続CHKZ.Size = New System.Drawing.Size(50, 20)
        Me.lbl接続CHKZ.TabIndex = 5
        Me.lbl接続CHKZ.Text = "OK"
        Me.lbl接続CHKZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCOMCHKX
        '
        Me.LblCOMCHKX.BackColor = System.Drawing.SystemColors.Control
        Me.LblCOMCHKX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCOMCHKX.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblCOMCHKX.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LblCOMCHKX.Location = New System.Drawing.Point(447, 28)
        Me.LblCOMCHKX.Name = "LblCOMCHKX"
        Me.LblCOMCHKX.Size = New System.Drawing.Size(50, 20)
        Me.LblCOMCHKX.TabIndex = 5
        Me.LblCOMCHKX.Text = "OK"
        Me.LblCOMCHKX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl接続CHKY
        '
        Me.lbl接続CHKY.BackColor = System.Drawing.SystemColors.Control
        Me.lbl接続CHKY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl接続CHKY.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl接続CHKY.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl接続CHKY.Location = New System.Drawing.Point(165, 61)
        Me.lbl接続CHKY.Name = "lbl接続CHKY"
        Me.lbl接続CHKY.Size = New System.Drawing.Size(50, 20)
        Me.lbl接続CHKY.TabIndex = 5
        Me.lbl接続CHKY.Text = "OK"
        Me.lbl接続CHKY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(510, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 20)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "--DIﾓｼﾞｭｰﾙ"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(510, 94)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 20)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "--距離計(Z軸)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(510, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 20)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "--距離計(Y軸)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(510, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "--距離計(X軸)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(227, 138)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(218, 20)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "--   DIﾓｼﾞｭｰﾙ用CPU     --"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(227, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(218, 20)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "--RS422ﾒﾃﾞｨｱｺﾝﾊﾞｰﾀ(Z軸)--"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(227, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(218, 20)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "--RS422ﾒﾃﾞｨｱｺﾝﾊﾞｰﾀ(Y軸)--"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(227, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "--RS422ﾒﾃﾞｨｱｺﾝﾊﾞｰﾀ(X軸)--"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(66, 138)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 20)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "管理端末--"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(66, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 20)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "管理端末--"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(66, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "管理端末--"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(66, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "管理端末--"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl接続CHKST1_Y
        '
        Me.lbl接続CHKST1_Y.BackColor = System.Drawing.SystemColors.Control
        Me.lbl接続CHKST1_Y.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl接続CHKST1_Y.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl接続CHKST1_Y.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl接続CHKST1_Y.Location = New System.Drawing.Point(755, 238)
        Me.lbl接続CHKST1_Y.Name = "lbl接続CHKST1_Y"
        Me.lbl接続CHKST1_Y.Size = New System.Drawing.Size(50, 20)
        Me.lbl接続CHKST1_Y.TabIndex = 5
        Me.lbl接続CHKST1_Y.Text = "OK"
        Me.lbl接続CHKST1_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl接続CHKST1_Y.Visible = False
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(796, 218)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(153, 20)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "--無線ｽﾃｰｼｮﾝZ --"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label22.Visible = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(796, 218)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(153, 20)
        Me.Label23.TabIndex = 1
        Me.Label23.Text = "--無線ｽﾃｰｼｮﾝZ --"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label23.Visible = False
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(796, 218)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(153, 20)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "--無線ｽﾃｰｼｮﾝZ --"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label24.Visible = False
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(796, 218)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(153, 20)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "--無線ｽﾃｰｼｮﾝZ --"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label25.Visible = False
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(796, 218)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(153, 20)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "--無線ｽﾃｰｼｮﾝZ --"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label26.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(796, 218)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(153, 20)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "--無線ｽﾃｰｼｮﾝZ --"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Visible = False
        '
        'lbl接続CHKST1_X
        '
        Me.lbl接続CHKST1_X.BackColor = System.Drawing.SystemColors.Control
        Me.lbl接続CHKST1_X.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl接続CHKST1_X.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl接続CHKST1_X.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl接続CHKST1_X.Location = New System.Drawing.Point(755, 238)
        Me.lbl接続CHKST1_X.Name = "lbl接続CHKST1_X"
        Me.lbl接続CHKST1_X.Size = New System.Drawing.Size(50, 20)
        Me.lbl接続CHKST1_X.TabIndex = 5
        Me.lbl接続CHKST1_X.Text = "OK"
        Me.lbl接続CHKST1_X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl接続CHKST1_X.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(796, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "--無線ｽﾃｰｼｮﾝXY--"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(796, 238)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "--無線ｽﾃｰｼｮﾝXY--"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(796, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 20)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "--無線ｽﾃｰｼｮﾝZ --"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Visible = False
        '
        'lbl接続CHKST2_Z
        '
        Me.lbl接続CHKST2_Z.BackColor = System.Drawing.SystemColors.Control
        Me.lbl接続CHKST2_Z.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl接続CHKST2_Z.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl接続CHKST2_Z.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl接続CHKST2_Z.Location = New System.Drawing.Point(755, 238)
        Me.lbl接続CHKST2_Z.Name = "lbl接続CHKST2_Z"
        Me.lbl接続CHKST2_Z.Size = New System.Drawing.Size(50, 20)
        Me.lbl接続CHKST2_Z.TabIndex = 5
        Me.lbl接続CHKST2_Z.Text = "OK"
        Me.lbl接続CHKST2_Z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl接続CHKST2_Z.Visible = False
        '
        'lbl接続CHKST2_D1
        '
        Me.lbl接続CHKST2_D1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl接続CHKST2_D1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl接続CHKST2_D1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl接続CHKST2_D1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl接続CHKST2_D1.Location = New System.Drawing.Point(755, 238)
        Me.lbl接続CHKST2_D1.Name = "lbl接続CHKST2_D1"
        Me.lbl接続CHKST2_D1.Size = New System.Drawing.Size(50, 20)
        Me.lbl接続CHKST2_D1.TabIndex = 5
        Me.lbl接続CHKST2_D1.Text = "OK"
        Me.lbl接続CHKST2_D1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl接続CHKST2_D1.Visible = False
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.SystemColors.Window
        Me.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCaption.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(1022, 48)
        Me.lblCaption.TabIndex = 9
        Me.lblCaption.Text = "レーザー距離計距離計測システム"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrNow
        '
        '
        'tmr7
        '
        '
        'レーザー距離計距離計測システム
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1016, 706)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn終了)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip)
        Me.DoubleBuffered = True
        Me.Name = "レーザー距離計距離計測システム"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "レーザー距離計距離計測システム　Ver.1.3.0.0"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Grp機器接続.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_CapX軸 As System.Windows.Forms.Label
    Friend WithEvents Lbl_DataZ軸 As System.Windows.Forms.Label
    Friend WithEvents Lbl_DataY軸 As System.Windows.Forms.Label
    Friend WithEvents Lbl_DataX軸 As System.Windows.Forms.Label
    Friend WithEvents Lbl_CapZ軸 As System.Windows.Forms.Label
    Friend WithEvents Lbl_CapY軸 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Cap計測時刻 As System.Windows.Forms.Label
    Friend WithEvents lbl_Data計測時刻 As System.Windows.Forms.Label
    Friend WithEvents lbl_Capファイル名 As System.Windows.Forms.Label
    Friend WithEvents lbl_Dataファイル名 As System.Windows.Forms.Label
    Friend WithEvents lblCap計測履歴 As System.Windows.Forms.Label
    Friend WithEvents txt計測履歴 As System.Windows.Forms.TextBox
    Friend WithEvents btn終了 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents Slbl現在時刻 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SLblシステム状態 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn機器チェック As System.Windows.Forms.Button
    Friend WithEvents txt機器状況 As System.Windows.Forms.TextBox
    Friend WithEvents lbl接続CHKST1_X As System.Windows.Forms.Label
    Friend WithEvents lbl接続CHKD1 As System.Windows.Forms.Label
    Friend WithEvents lbl接続CHKZ As System.Windows.Forms.Label
    Friend WithEvents lbl接続CHKST2_Z As System.Windows.Forms.Label
    Friend WithEvents lbl接続CHKY As System.Windows.Forms.Label
    Friend WithEvents lbl接続CHKX As System.Windows.Forms.Label
    Friend WithEvents LblCOMCHKD1 As System.Windows.Forms.Label
    Friend WithEvents LblCOMCHKZ As System.Windows.Forms.Label
    Friend WithEvents LblCOMCHKY As System.Windows.Forms.Label
    Friend WithEvents LblCOMCHKX As System.Windows.Forms.Label
    Friend WithEvents lblDataZ軸CHK As System.Windows.Forms.Label
    Friend WithEvents lblDataY軸CHK As System.Windows.Forms.Label
    Friend WithEvents lblCapX軸CHK As System.Windows.Forms.Label
    Friend WithEvents lblCapY軸CHK As System.Windows.Forms.Label
    Friend WithEvents lblCapZ軸CHK As System.Windows.Forms.Label
    Friend WithEvents lblDataX軸CHK As System.Windows.Forms.Label
    Friend WithEvents lblDataトングSTS As System.Windows.Forms.Label
    Friend WithEvents lblCapトングSTS As System.Windows.Forms.Label
    Friend WithEvents lblCapInCHK As System.Windows.Forms.Label
    Friend WithEvents lblData入力トングSTS As System.Windows.Forms.Label
    Friend WithEvents lblData入力電源 As System.Windows.Forms.Label
    Friend WithEvents Grp機器接続 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl接続CHKST1_Y As System.Windows.Forms.Label
    Friend WithEvents lbl接続CHKST2_D1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblD入力トングSTS As System.Windows.Forms.Label
    Friend WithEvents lblD入力電源 As System.Windows.Forms.Label
    Friend WithEvents lblDataRKZ As System.Windows.Forms.Label
    Friend WithEvents lblDataRKY As System.Windows.Forms.Label
    Friend WithEvents lblDataRKX As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tmrNow As System.Windows.Forms.Timer
    Friend WithEvents tmr7 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Lbltest_C_TNG As System.Windows.Forms.Label
    Friend WithEvents Lbltest_C_POW As System.Windows.Forms.Label
    Friend WithEvents Lbltest_P_TNG As System.Windows.Forms.Label
    Friend WithEvents Lbltest_P_POW As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Lbltest_TNG As System.Windows.Forms.Label
    Friend WithEvents Lbltest_POW As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
