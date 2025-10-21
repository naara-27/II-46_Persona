Imports System.Data.SqlClient

Public Class DataBaseHelper
    Private ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("II46_P3ConnectionString").ConnectionString
    Public Function create(Persona As Persona) As String
        Try
            Dim sql As String = "INSERT INTO PERSONA (NOMBRE, APELLIDO, EDAD) VALUES (@Nombre, @Apellido, @Edad)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido", Persona.Apellido),
                New SqlParameter("@Edad", Persona.Edad)
            }

            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception

        End Try
        Return "Persona Creada"
    End Function

    Public Function delete(ByRef id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM PERSONA WHERE ID = @Id"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id)
            }
            Using connetion As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception

        End Try

        Return "Persona Eliminada"
    End Function

    Public Function update(ByRef persona As Persona) As String
        Try
            Dim sql As String = "UPDATE PERSONA SET NOMBRE = @Nombre, APELLIDO = @Apellido, EDAD = @Edad WHERE ID = @Id"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Id", persona.ID),
                New SqlParameter("@Nombre", persona.Nombre),
                New SqlParameter("@Apellido", persona.Apellido),
                New SqlParameter("@Edad", persona.Edad)
            }
            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return "Persona Actualizada"
    End Function
End Class
