Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class Cadastro
    Public IdCliente As Integer = 0

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        GravarDados()
        Me.Close()
    End Sub

    Private Sub GravarDados()
        Dim classe As New DadosClientes
        Dim objeto As New DadosClientes.ClientesObj

        objeto.Nome = txtNome.Text.Trim()
        objeto.Endereco = txtEndereco.Text.Trim()
        objeto.Cidade = txtCidade.Text.Trim()
        objeto.Telefone = txtTelefone.Text.Trim()
        objeto.Email = txtEmail.Text.Trim()
        objeto.Ativo = ckbAtivo.Checked

        If (Me.IdCliente > 0) Then
            objeto.IdCliente = IdCliente
            classe.AtualizarCliente(objeto)
            MessageBox.Show("Dados atualizados com sucesso!", "Atenção")
        Else
            classe.IncluirCliente(objeto)
            MessageBox.Show("Cliente cadastrado com sucesso!", "Atenção")
        End If

    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub Cadastro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSaveWebAPI_Click(sender As Object, e As EventArgs) Handles btnSaveWebAPI.Click
        Dim objeto As New DadosClientes.ClientesObj

        objeto.Nome = txtNome.Text.Trim()
        objeto.Endereco = txtEndereco.Text.Trim()
        objeto.Cidade = txtCidade.Text.Trim()
        objeto.Telefone = txtTelefone.Text.Trim()
        objeto.Email = txtEmail.Text.Trim()
        objeto.Ativo = ckbAtivo.Checked

        If (Me.IdCliente > 0) Then
            objeto.IdCliente = IdCliente
            AtualizarRegistroWebApi(objeto)
            MessageBox.Show("Dados atualizados com sucesso!", "Atenção")
        Else
            IncluirRegistroWebApi(objeto)
            MessageBox.Show("Cliente cadastrado com sucesso!", "Atenção")
        End If
        Me.Close()
    End Sub

    Private Async Sub IncluirRegistroWebApi(ByVal cliente As DadosClientes.ClientesObj)
        Using client = New HttpClient()
            Dim c = JsonConvert.SerializeObject(cliente)
            Dim content = New StringContent(c, Encoding.UTF8, "application/json")
            Dim retorno = Await client.PostAsync(txtUrl.Text, content)
        End Using
    End Sub

    Private Async Sub AtualizarRegistroWebApi(ByVal cliente As DadosClientes.ClientesObj)
        Using client = New HttpClient()
            Dim c = JsonConvert.SerializeObject(cliente)
            Dim content = New StringContent(c, Encoding.UTF8, "application/json")
            Dim retorno = Await client.PutAsync(txtUrl.Text & CStr(cliente.IdCliente), content)
        End Using
    End Sub
End Class
