Public Class manual_data
    Public Post_Edit As Boolean = False

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Geef alle data terug aan de main form
        'Ze dialogresult op OK
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub manual_data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Post_Edit = True Then
            grp_trial.Enabled = True
        Else
            grp_trial.Enabled = False
        End If
    End Sub
End Class