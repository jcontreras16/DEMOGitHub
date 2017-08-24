Imports System.Globalization
Imports System.Threading
Imports ColRestriccion_BL

Partial Class QuantaMastePage : Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try

            Dim usuario As String
            Dim dom As String
            Dim Logon_User As String = Request.ServerVariables("LOGON_USER")

            If Session("CuentaUsuario") = Nothing Then
                usuario = Logon_User.Substring(7)
                dom = "QUANTA"
                Session("Dom") = dom
                Session("CuentaUsuario") = usuario
            Else
                usuario = Session("CuentaUsuario")
            End If

            'Obteniendo la OPU:
            Dim OPU As Integer
            OPU = "Usuario_BL.COL_RESTRICCION_OBTENER_OPU(usuario)"
            Session("OPU") = OPU

            'Español:
            Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE")

        Catch ex As Exception
            lbl_error.Text = "Error Master Page: " + ex.Message
        End Try
    End Sub

End Class

