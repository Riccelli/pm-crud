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
End Class
