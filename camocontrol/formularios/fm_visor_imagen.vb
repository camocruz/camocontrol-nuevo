Public Class fm_visor_imagen
    'Objetos publicos que reciben valores desde el Formulario padre
    'Public vf_oform_padre As Object
    Public ocontexto_form As String = ""
    '$Public$vg_usuario_autoriza As String = ""
    Public nombre_usuario_autoriza As String = ""
    Public autoriza As String = "N"
    '$Public$vg_id_cia As String = ""

    Public path_file As String = ""


    Private bitmap1 As Bitmap

    Private Sub fm_visor_imagen_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Dim imagen As Image
        'imagen = Image.FromFile(path_file)
        'PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        'PictureBox2.Image = imagen
        'PictureBox2.Height = imagen.Height
        'PictureBox2.Width = imagen.Width
        'Panel1.AutoScroll = True 'Ponemos a True esta opción para que se muestren las barras de desplazamiento

        With nud_escala_imagen
            .Maximum = 10 ' valor máximo   
            .Minimum = 0.1 ' minimo  
            .Value = 1
            .Increment = 0.1
            .DecimalPlaces = 1
        End With

        bitmap1 = CType(Bitmap.FromFile(path_file), Bitmap)
        PictureBox2.Height = bitmap1.Height
        PictureBox2.Width = bitmap1.Width

        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.Image = bitmap1

        'Panel1.AutoScrollMinSize = PictureBox1.Image.Size 'Asignamos a las barras de desplazamiento del panel el tamaño de la imagen
        Panel1.AutoScroll = True 'Ponemos a True esta opción para que se muestren las barras de desplazamiento

    End Sub

    Sub Cambiar(ByVal Picbox As PictureBox, ByVal Escala As Single)
        Dim Ancho As Single, Alto As Single
        ' si hay una imagen ...  
        If Not Picbox.Image Is Nothing Then

            Picbox.SizeMode = PictureBoxSizeMode.Zoom
            With Picbox
                ' Ancho y alto de la imagen     
                Ancho = .Image.Width * Escala
                Alto = .Image.Height * Escala
                .Width = Ancho
                .Height = Alto
            End With
        End If
    End Sub

    Private Sub nud_escala_imagen_ValueChanged(sender As Object, e As EventArgs) Handles nud_escala_imagen.ValueChanged
        If bitmap1 IsNot Nothing Then
            ' cambia de tamaño el picbox según el valor de escala  
            Cambiar(PictureBox2, CSng(nud_escala_imagen.Value))
        End If
    End Sub

    Private Sub bt_rotar_imagen_derecha_Click(sender As Object, e As EventArgs) Handles bt_rotar_imagen_derecha.Click
        If bitmap1 IsNot Nothing Then
            bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone)
            PictureBox2.Image = bitmap1
        End If
    End Sub

    Private Sub bt_rotar_imagen_izquierda_Click(sender As Object, e As EventArgs) Handles bt_rotar_imagen_izquierda.Click
        If bitmap1 IsNot Nothing Then
            bitmap1.RotateFlip(RotateFlipType.Rotate270FlipNone)
            PictureBox2.Image = bitmap1
        End If
    End Sub
End Class
