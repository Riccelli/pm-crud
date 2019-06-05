Public Class ClienteObj
    Public IdCliente As Integer = 0
    Public Nome As String = String.Empty
    Public Endereco As String = String.Empty
    Public Cidade As String = String.Empty
    Public Telefone As String = String.Empty
    Public Email As String = String.Empty
    Public Ativo As Boolean = False

    Public Sub New()
    End Sub

    Public Sub New(ByVal IdCliente As Integer, ByVal Nome As String,
                   ByVal Endereco As String, ByVal Cidade As String, ByVal Telefone As String,
                   ByVal Email As String, ByVal Ativo As Boolean)
        Me.IdCliente = IdCliente
        Me.Nome = Nome
        Me.Endereco = Endereco
        Me.Cidade = Cidade
        Me.Telefone = Telefone
        Me.Email = Email
        Me.Ativo = Ativo
    End Sub
End Class
