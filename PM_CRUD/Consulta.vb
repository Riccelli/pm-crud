Imports System.Net.Http
Imports Newtonsoft.Json

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
            Dim codigo As Integer = Integer.Parse(lsvDados.Items(Me.index).Text)
            ExcluirRegistro(Integer.Parse(lsvDados.Items(Me.index).Text))
            CarregarListView()
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

    Private Sub btnGetWebAPI_Click(sender As Object, e As EventArgs) Handles btnGetWebAPI.Click
        GetClientesWebApi()
    End Sub

    Private Async Sub GetClientesWebApi()
        Using client = New HttpClient()
            Using response = Await client.GetAsync(txtUrl.Text)
                If response.IsSuccessStatusCode Then
                    Dim str = Await response.Content.ReadAsStringAsync()
                    Dim clientes = JsonConvert.DeserializeObject(Of DadosClientes.ClientesObj())(str).ToList()

                    lsvDados.Items.Clear()

                    For Each cliente As DadosClientes.ClientesObj In clientes
                        Dim lista As New ListViewItem
                        lista.Text = cliente.IdCliente
                        lista.SubItems.Add(cliente.Nome)
                        lista.SubItems.Add(cliente.Endereco)
                        lista.SubItems.Add(cliente.Cidade)
                        lista.SubItems.Add(cliente.Telefone)
                        lista.SubItems.Add(cliente.Email)

                        If cliente.Ativo Then
                            lista.SubItems.Add("Sim")
                        Else
                            lista.SubItems.Add("Não")
                        End If

                        lsvDados.Items.Add(lista)
                    Next
                End If
            End Using
        End Using
    End Sub

    Private Sub btnDeleteWebApi_Click(sender As Object, e As EventArgs) Handles btnDeleteWebApi.Click
        If lsvDados.SelectedItems.Count > 0 Then
            Dim nome As String
            nome = lsvDados.Items(index).SubItems(1).Text
            ExcluirRegistroWebApi(Integer.Parse(lsvDados.Items(Me.index).Text))
            GetClientesWebApi()
        Else
            MessageBox.Show("Por favor, selecione um cliente a ser excluído!", "Atenção")
        End If
    End Sub

    Private Async Sub ExcluirRegistroWebApi(ByVal id As Integer)
        Using client = New HttpClient()
            Dim url = txtUrl.Text & CStr(id)
            Dim retorno = Await client.DeleteAsync(url)
        End Using
    End Sub
End Class