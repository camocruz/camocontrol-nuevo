Public Class DropDownCheckedListBox
    Private Const T_DisplayListSize As Integer = 6
    Private Const SelectNoneText As String = "(None Selected)"
    Private Const SelectAllText As String = "(All Selected)"
    Private Const SelectSomeText As String = "(Some Selected...)"
    Private Frm As Form
    Private LostFocus As Boolean
    Private CodeValue As String
    Private T_MustFill As Boolean
    Private Shared m_ChkItemsString As String
    Public Event DropDown()
    Public Shadows Event TextChanged()
    Public Event SetStatusPrompt(ByVal Sender As DropDownCheckedListBox)
    Public Event AllItemSelected(ByVal Sender As DropDownCheckedListBox)
    Public Event AllItemDeselected(ByVal Sender As DropDownCheckedListBox)

#Region "Properties"
    'Make some public properties for the itemslist and length of dropdown list etc.

    Private dataList() As String
    Public Property Items() As String()
        Get
            Return dataList
        End Get
        Set(ByVal value As String())
            dataList = value
        End Set
    End Property
    Private ListSize As Integer
    Public Property DisplayListSize() As Integer
        Get
            Return ListSize
        End Get
        Set(ByVal value As Integer)
            ListSize = value
            SetList()
        End Set
    End Property
    Private T_DroppedDown As Boolean
    Public ReadOnly Property DroppedDown() As Boolean
        Get
            Return T_DroppedDown
        End Get
    End Property
    Private T_ListText As String
    Public ReadOnly Property ListText() As String
        Get
            Return T_ListText
        End Get
    End Property
#End Region

    'Add new function InitializeNew() in Sub new()
    Public Sub New()
        InitializeComponent()
        InitializeNew()
    End Sub
    Private Sub InitializeNew()
        Dim strTemp As String = vbEmpty
        ListSize = T_DisplayListSize
        T_DroppedDown = False
        T_ListText = ""
        T_MustFill = False
        txt.Text = strTemp
        chkListBox.Hide()
        Frm = New Form
        With Frm
            .ShowInTaskbar = False
            .FormBorderStyle = FormBorderStyle.None
            .ControlBox = False
            .StartPosition = FormStartPosition.Manual
            .TopMost = True
            .Location = chkListBox.Location
            .Width = chkListBox.Width
            .Controls.Add(chkListBox)
        End With
        SetSize()
    End Sub

    'Create mousedown event of btnDropDown button and call function listButtonClick on here. 
    'This Is responsible for showing checkedListBox

    Private Sub btnDropdown_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnDropdown.MouseDown
        ListButtonClick()
    End Sub

    'We have already make two custom event one is TextChanged and another is DropDown, 
    'On here both event have been raised. 
    'So we can handle events When control changes its status(user check Or uncheck item(s)).

    Private Sub ListButtonClick()
        Dim strTemp As String
        strTemp = T_ListText
        If T_DroppedDown Then
            T_DroppedDown = False
            txt.Text = GetSelectedItems()
            chkListBox.Hide()
            Frm.Hide()
            txt.Focus()
            If Not strTemp = T_ListText Then
                RaiseEvent TextChanged()
            End If
        ElseIf Not LostFocus Then
            T_DroppedDown = True
            SetSize()
            Frm.Show()
            chkListBox.Show()
            chkListBox.Focus()
            RaiseEvent DropDown()
        End If
        LostFocus = False
    End Sub

    Private Function GetSelectedItems() As String
        Dim strLst As String
        Dim blnAllSelected As Boolean = False
        strLst = ""
        With chkListBox
            If .Items.Count > 0 Then
                If .CheckedIndices.Count = 0 Then
                    strLst = SelectNoneText
                Else
                    If .CheckedIndices.Count = .Items.Count Then
                        strLst = SelectAllText
                    Else
                        strLst = .CheckedIndices.Count & " selected" 'SelectSomeText
                    End If
                End If
            Else
                strLst = SelectNoneText
            End If
        End With
        Return strLst
    End Function

    Private Sub SetList()
        Dim oFrm As Form
        Dim oRect As Rectangle
        Dim oPt As Point
        If Frm IsNot Nothing Then
            Frm.Height = (ListSize * chkListBox.ItemHeight) + 3
            chkListBox.Height = Frm.Height
            chkListBox.Top = 0
            oFrm = Me.FindForm
            If oFrm IsNot Nothing Then
                oPt = Me.ParentForm.PointToClient(Me.PointToScreen(Point.Empty))
                oPt.Y = oPt.Y + Me.txt.Height
                oRect = oFrm.RectangleToScreen(oFrm.ClientRectangle)
                oPt.X = oPt.X + oRect.Left
                oPt.Y = oPt.Y + oRect.Top
                Frm.Location = oPt
            End If
            Frm.Width = chkListBox.Width
        End If
    End Sub

    'SetSize() function works for set the size of all controls if you can resize usercontrol.
    Private Sub SetSize()
        LostFocus = False
        txt.Width = Me.Width
        btnDropdown.Left = txt.Width - btnDropdown.Width - 2
        chkListBox.Width = Me.Width
        Me.Height = txt.Height
        SetList()
    End Sub


End Class
