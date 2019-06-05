Imports System.Data.SqlClient
Imports WebApi.ClienteObj

Public Class DadosClientes
    Public Const strConexao As String = "Data Source=(local);Initial Catalog=pm_crud;Integrated Security=True"
    Public strInstrucao As String = String.Empty
    Public objConexao As New SqlConnection(strConexao)
    Public objCommand As New SqlCommand(strInstrucao, objConexao)

    Public Sub IncluirCliente(ByVal cliente As ClienteObj)

        strInstrucao = "INSERT INTO Clientes VALUES (@Nome, @Endereco, @Cidade, @Telefone, @Email, @Ativo)"
        objCommand.CommandText = strInstrucao
        objCommand.Connection = objConexao
        objCommand.Parameters.AddWithValue("@Nome", cliente.Nome)
        objCommand.Parameters.AddWithValue("@Endereco", cliente.Endereco)
        objCommand.Parameters.AddWithValue("@Cidade", cliente.Cidade)
        objCommand.Parameters.AddWithValue("@Telefone", cliente.Telefone)
        objCommand.Parameters.AddWithValue("@Email", cliente.Email)
        objCommand.Parameters.AddWithValue("@Ativo", cliente.Ativo)

        objConexao.Open()
        objCommand.ExecuteNonQuery()
        objConexao.Close()

    End Sub

    Public Sub AtualizarCliente(ByVal clientes As ClienteObj)

        strInstrucao = "UPDATE Clientes SET 
            Nome = @Nome, Endereco = @Endereco, Cidade = @Cidade, 
            Telefone = @Telefone, Email = @Email, Ativo = @Ativo
            where IdCliente = @IdCliente"

        objCommand.CommandText = strInstrucao
        objCommand.Connection = objConexao
        objCommand.Parameters.AddWithValue("@IdCliente", clientes.IdCliente)
        objCommand.Parameters.AddWithValue("@Nome", clientes.Nome)
        objCommand.Parameters.AddWithValue("@Endereco", clientes.Endereco)
        objCommand.Parameters.AddWithValue("@Cidade", clientes.Cidade)
        objCommand.Parameters.AddWithValue("@Telefone", clientes.Telefone)
        objCommand.Parameters.AddWithValue("@Email", clientes.Email)
        objCommand.Parameters.AddWithValue("@Ativo", clientes.Ativo)

        objConexao.Open()
        objCommand.ExecuteNonQuery()
        objConexao.Close()

    End Sub

    Public Sub ExcluirCliente(ByVal IdCliente As Integer)

        strInstrucao = "DELETE FROM Clientes WHERE IdCliente = @IdCliente"
        objCommand.CommandText = strInstrucao
        objCommand.Connection = objConexao
        objCommand.Parameters.AddWithValue("@IdCliente", IdCliente)

        objConexao.Open()
        objCommand.ExecuteNonQuery()
        objConexao.Close()

    End Sub

    Public Function ConsultarClientes() As IEnumerable(Of ClienteObj)

        Dim dt As New DataTable
        Dim ds As New DataSet()
        strInstrucao = "SELECT IdCliente, Nome, Endereco, Cidade, Telefone, Email, Ativo FROM Clientes"
        objCommand.CommandText = strInstrucao
        objCommand.Connection = objConexao

        objConexao.Open()
        Dim reader As SqlDataReader = objCommand.ExecuteReader()
        Dim clientes As List(Of ClienteObj) = ConvertReader(reader)
        objConexao.Close()

        Return clientes

    End Function

    Public Function ConsultarClientes(ByVal IdCliente As Integer) As ClienteObj

        Dim dt As New DataTable
        Dim ds As New DataSet()
        strInstrucao = "SELECT IdCliente, Nome, Endereco, Cidade, Telefone, Email, Ativo FROM Clientes
            where IdCliente = @IdCliente"
        objCommand.CommandText = strInstrucao
        objCommand.Connection = objConexao
        objCommand.Parameters.AddWithValue("@IdCliente", IdCliente)

        objConexao.Open()
        Dim reader As SqlDataReader = objCommand.ExecuteReader()
        Dim clientes As List(Of ClienteObj) = ConvertReader(reader)
        objConexao.Close()

        Return clientes.FirstOrDefault()

    End Function

    Public Function ConvertReader(ByVal reader As SqlDataReader)
        Dim clientes As List(Of ClienteObj) = New List(Of ClienteObj)
        If reader.HasRows Then
            While reader.Read()
                clientes.Add(New ClienteObj(
                             CInt(reader.Item("IdCliente")),
                             reader.Item("Nome").ToString(),
                             reader.Item("Endereco").ToString(),
                             reader.Item("Cidade").ToString(),
                             reader.Item("Telefone").ToString(),
                             reader.Item("Email").ToString(),
                             CBool(reader.Item("Ativo"))))
            End While
            reader.Close()
        End If
        Return clientes
    End Function
End Class
