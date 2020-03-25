Public Class Form1
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click, PictureBox5.Click, PictureBox3.Click, PictureBox1.Click

    End Sub
    Dim speed As Integer
    Dim road(7) As PictureBox
    Dim score As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        speed = 3
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8

    End Sub

    Private Sub RoadMover_Tick(sender As Object, e As EventArgs) Handles RoadMover.Tick
        For x As Integer = 0 To 7
            road(x).Top += speed
            If road(x).Top >= Me.Height Then
                road(x).Top = -road(x).Height
            End If
        Next
        If score > 10 And score < 20 Then
            speed = 5
        End If
        If score > 20 And score < 30 Then
            speed = 6
        End If
        If score > 30 Then
            speed = 7
        End If
        speed_text.Text = "Speed " & speed
            If (Car.Bounds.IntersectsWith(EnemyCar1.Bounds)) Then
                gameOver()
            End If
            If (Car.Bounds.IntersectsWith(EnemyCar2.Bounds)) Then
                gameOver()
            End If
            If (Car.Bounds.IntersectsWith(EnemyCar3.Bounds)) Then
                gameOver()
            End If

    End Sub
    Private Sub gameOver()
        replay_button.Visible = True
        End_text.Visible = True
        RoadMover.Stop()
        Enemy1_mover.Stop()
        Enemy2_mover.Stop()
        Enemy3_mover.Stop()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub Car_Click(sender As Object, e As EventArgs) Handles Car.Click

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            Right_mover.Start()
        End If
        If e.KeyCode = Keys.Left Then
            Left_mover.Start()
        End If
    End Sub

    Private Sub Right_mover_Tick(sender As Object, e As EventArgs) Handles Right_mover.Tick
        If (Car.Location.X < 183) Then
            Car.Left += 5
        End If
    End Sub

    Private Sub Left_mover_Tick(sender As Object, e As EventArgs) Handles Left_mover.Tick
        If (Car.Location.X > 0) Then
            Car.Left -= 5
        End If

    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Right_mover.Stop()
        Left_mover.Stop()

    End Sub

    Private Sub Enemy1_mover_Tick(sender As Object, e As EventArgs) Handles Enemy1_mover.Tick
        EnemyCar1.Top += speed * 2
        If EnemyCar1.Top >= Me.Height Then
            score += 1
            Score_text.Text = "Score " & score
            EnemyCar1.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar1.Height)
            EnemyCar1.Left = CInt(Math.Ceiling(Rnd() * 50)) + 0
        End If

    End Sub

    Private Sub Enemy2_mover_Tick(sender As Object, e As EventArgs) Handles Enemy2_mover.Tick
        EnemyCar2.Top += speed * 2
        If EnemyCar2.Top >= Me.Height Then
            score += 1
            Score_text.Text = "Score " & score
            EnemyCar2.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar2.Height)
            EnemyCar2.Left = CInt(Math.Ceiling(Rnd() * 50)) + 90
        End If
    End Sub

    Private Sub Enemy3_mover_Tick(sender As Object, e As EventArgs) Handles Enemy3_mover.Tick
        EnemyCar3.Top += speed * 3 / 2
        If EnemyCar3.Top >= Me.Height Then
            score += 1
            Score_text.Text = "Score " & score
            EnemyCar3.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + EnemyCar3.Height)
            EnemyCar3.Left = CInt(Math.Ceiling(Rnd() * 50)) + 170
        End If
    End Sub

    Private Sub replay_button_Click(sender As Object, e As EventArgs) Handles replay_button.Click
        score = 0
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)

    End Sub
End Class
