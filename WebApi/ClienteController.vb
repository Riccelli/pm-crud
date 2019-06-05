Imports System.Net
Imports System.Web.Http

Public Class ClienteController
    Inherits ApiController

    Dim dc = New DadosClientes()

    ' GET api/<controller>
    Public Function GetValues() As IEnumerable(Of ClienteObj)
        Return dc.ConsultarClientes()
    End Function

    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As ClienteObj
        Return dc.ConsultarClientes(id)
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As ClienteObj)
        dc.IncluirCliente(value)
    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As ClienteObj)
        value.IdCliente = id
        dc.AtualizarCliente(value)
    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)
        dc.ExcluirCliente(id)
    End Sub
End Class
