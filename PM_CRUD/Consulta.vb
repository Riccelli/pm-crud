Public Class Consulta
    Public index As Integer = -1

    Private Sub Consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarListView()
    End Sub

    Private Sub lsvDados_Click(sender As Object, e As EventArgs) Handles lsvDados.Click
        If lsvDados.SelectedItems.Count > 0 Then
            Me.index = lsvDados.SelectedItems(0).Index
        Else
            Me.index = -1
        End If
    End Sub

    Private Sub CarregarListView()

        Dim objDados As New DadosClientes()
        Dim dt As New DataTable
        dt = objDados.ConsultarClientes()

        lsvDados.Items.Clear()

        For Each linha As DataRow In dt.Rows
            Dim lista As New ListViewItem
            lista.Text = linha("IdCliente").ToString()
            lista.SubItems.Add(linha("Nome").ToString())
            lista.SubItems.Add(linha("Endereco").ToString())
            lista.SubItems.Add(linha("Cidade").ToString())
            lista.SubItems.Add(linha("Telefone").ToString())
            lista.SubItems.Add(linha("Email").ToString())

            If linha("Ativo").ToString().Equals("True") Then
                lista.SubItems.Add("Sim")
            Else
                lista.SubItems.Add("Não")
            End If

            lsvDados.Items.Add(lista)
        Next

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If lsvDados.SelectedItems.Count > 0 Then
            Dim nome As String
            nome = lsvDados.Items(index).SubItems(1).Text
            If MessageBox.Show(
                    "Confirma a exclusão do cliente " & nome & " ?",
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) = 1 Then
                ExcluirRegistro(Integer.Parse(lsvDados.Items(Me.index).Text))
                CarregarListView()
            End If
        Else
            MessageBox.Show("Por favor, selecione um cliente a ser excluído!", "Atenção")
        End If
    End Sub

    Private Sub ExcluirRegistro(ByVal IdCliente As Integer)
        Dim objDados As New DadosClientes()
        objDados.ExcluirCliente(IdCliente)
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        If lsvDados.SelectedItems.Count > 0 Then
            Dim instancia As New Cadastro()
            instancia.IdCliente = Integer.Parse(lsvDados.Items(index).Text)
            instancia.lblCodigo.Text = lsvDados.Items(index).Text
            instancia.txtNome.Text = lsvDados.Items(index).SubItems(1).Text
            instancia.txtEndereco.Text = lsvDados.Items(index).SubItems(2).Text
            instancia.txtCidade.Text = lsvDados.Items(index).SubItems(3).Text
            instancia.txtTelefone.Text = lsvDados.Items(index).SubItems(4).Text
            instancia.txtEmail.Text = lsvDados.Items(index).SubItems(5).Text

            If lsvDados.Items(index).SubItems(6).Text.Equals("Sim") Then
                instancia.ckbAtivo.Checked = True
            Else
                instancia.ckbAtivo.Checked = False
            End If

            instancia.ShowDialog()
            CarregarListView()
        Else
            MessageBox.Show("Nenhum cliente selecionado!", "Atenção")
        End If
    End Sub

    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        Dim instancia As New Cadastro()
        instancia.IdCliente = 0
        instancia.lblCodigo.Text = "0"
        instancia.ShowDialog()
        CarregarListView()
    End Sub
End Class