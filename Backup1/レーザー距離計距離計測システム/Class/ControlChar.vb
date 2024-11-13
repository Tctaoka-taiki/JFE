''' <summary>
''' 制御文字
''' </summary>
''' <remarks></remarks>
Public Class ControlChar

    ''' <summary>
    ''' テキストスタート(HEX : 02H = CTR B)
    ''' </summary>
    ''' <remarks></remarks>
    Public Const STX As Char = CChar(ChrW(2))

    ''' <summary>
    ''' 伝送終了(HEX : 04H = CTRL D)
    ''' </summary>
    ''' <remarks></remarks>
    Public Const EOT As Char = CChar(ChrW(4))

    ''' <summary>
    ''' 肯定応答(HEX : 06H)
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ACK As Char = CChar(ChrW(6))

End Class
