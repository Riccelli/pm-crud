<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consulta
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lsvDados = New System.Windows.Forms.ListView()
        Me.Código = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Endereço = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cidade = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Telefone = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Email = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Ativo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnGetWebAPI = New System.Windows.Forms.Button()
        Me.btnDeleteWebApi = New System.Windows.Forms.Button()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lsvDados
        '
        Me.lsvDados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Código, Me.Nome, Me.Endereço, Me.Cidade, Me.Telefone, Me.Email, Me.Ativo})
        Me.lsvDados.FullRowSelect = True
        Me.lsvDados.GridLines = True
        Me.lsvDados.Location = New System.Drawing.Point(12, 12)
        Me.lsvDados.MultiSelect = False
        Me.lsvDados.Name = "lsvDados"
        Me.lsvDados.Size = New System.Drawing.Size(633, 249)
        Me.lsvDados.TabIndex = 0
        Me.lsvDados.UseCompatibleStateImageBehavior = False
        Me.lsvDados.View = System.Windows.Forms.View.Details
        '
        'Código
        '
        Me.Código.Text = "Código"
        Me.Código.Width = 45
        '
        'Nome
        '
        Me.Nome.Text = "Nome"
        Me.Nome.Width = 150
        '
        'Endereço
        '
        Me.Endereço.Text = "Endereço"
        Me.Endereço.Width = 120
        '
        'Cidade
        '
        Me.Cidade.Text = "Cidade"
        '
        'Telefone
        '
        Me.Telefone.Text = "Telefone"
        Me.Telefone.Width = 80
        '
        'Email
        '
        Me.Email.Text = "Email"
        Me.Email.Width = 120
        '
        'Ativo
        '
        Me.Ativo.Text = "Ativo"
        '
        'btnAlterar
        '
        Me.btnAlterar.Location = New System.Drawing.Point(93, 335)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(75, 23)
        Me.btnAlterar.TabIndex = 1
        Me.btnAlterar.Text = "Alterar"
        Me.btnAlterar.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.Location = New System.Drawing.Point(174, 335)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btnExcluir.TabIndex = 2
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'btnSair
        '
        Me.btnSair.Location = New System.Drawing.Point(570, 335)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(75, 23)
        Me.btnSair.TabIndex = 3
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'btnNovo
        '
        Me.btnNovo.Location = New System.Drawing.Point(12, 335)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(75, 23)
        Me.btnNovo.TabIndex = 4
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnGetWebAPI
        '
        Me.btnGetWebAPI.Location = New System.Drawing.Point(12, 267)
        Me.btnGetWebAPI.Name = "btnGetWebAPI"
        Me.btnGetWebAPI.Size = New System.Drawing.Size(156, 23)
        Me.btnGetWebAPI.TabIndex = 5
        Me.btnGetWebAPI.Text = "Carregar usando WebApi"
        Me.btnGetWebAPI.UseVisualStyleBackColor = True
        '
        'btnDeleteWebApi
        '
        Me.btnDeleteWebApi.Location = New System.Drawing.Point(174, 267)
        Me.btnDeleteWebApi.Name = "btnDeleteWebApi"
        Me.btnDeleteWebApi.Size = New System.Drawing.Size(156, 23)
        Me.btnDeleteWebApi.TabIndex = 6
        Me.btnDeleteWebApi.Text = "Excluir usando WebApi"
        Me.btnDeleteWebApi.UseVisualStyleBackColor = True
        '
        'txtUrl
        '
        Me.txtUrl.Location = New System.Drawing.Point(85, 296)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(245, 20)
        Me.txtUrl.TabIndex = 7
        Me.txtUrl.Text = "http://localhost:54458/api/Cliente/"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 299)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Web API url:"
        '
        'Consulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 370)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUrl)
        Me.Controls.Add(Me.btnDeleteWebApi)
        Me.Controls.Add(Me.btnGetWebAPI)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnAlterar)
        Me.Controls.Add(Me.lsvDados)
        Me.Name = "Consulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Clientes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lsvDados As ListView
    Friend WithEvents btnAlterar As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnSair As Button
    Friend WithEvents Código As ColumnHeader
    Friend WithEvents Nome As ColumnHeader
    Friend WithEvents Endereço As ColumnHeader
    Friend WithEvents Telefone As ColumnHeader
    Friend WithEvents Email As ColumnHeader
    Friend WithEvents Ativo As ColumnHeader
    Friend WithEvents btnNovo As Button
    Friend WithEvents Cidade As ColumnHeader
    Friend WithEvents btnGetWebAPI As Button
    Friend WithEvents btnDeleteWebApi As Button
    Friend WithEvents txtUrl As TextBox
    Friend WithEvents Label1 As Label
End Class
