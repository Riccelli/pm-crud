Imports System.Data.SqlClient


Public Class DadosClientes
    Public Const strConexao As String = "Data Source=(local);Initial Catalog=pm_crud;Integrated Security=True"
    Public strInstrucao As String = String.Empty
    Public objConexao As New SqlConnection(strConexao)
    Public objCommand As New SqlCommand(strInstrucao, objConexao)

    Public Class ClientesObj
        Public IdCliente As Integer = 0
        Public Nome As String = String.Empty
        Public Endereco As String = String.Empty
        Public Cidade As String = String.Empty
        Public Telefone As String = String.Empty
        Public Email As String = String.Empty
        Public Ativo As Boolean = False
    End Class

    Public Sub IncluirCliente(ByVal cliente As ClientesObj)

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

    Public Sub AtualizarCliente(ByVal clientes As ClientesObj)

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

    Public Function ConsultarClientes() As DataTable

        Dim dt As New DataTable
        Dim ds As New DataSet()
        strInstrucao = "SELECT IdCliente, Nome, Endereco, Telefone, Email, Ativo FROM Clientes"
        objCommand.CommandText = strInstrucao
        objCommand.Connection = objConexao

        objConexao.Open()
        Dim da As New SqlDataAdapter(objCommand)
        da.Fill(ds)
        dt = ds.Tables(0)

        objConexao.Close()
        Return dt

    End Function
End Class
