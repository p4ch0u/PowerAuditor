Attribute VB_Name = "CustomRibbonTab"
Option Explicit
' PowerAuditor - A simple script to help report writing by https://github.com/1mm0rt41PC
'
' Filename: CustomRibbonTab.bas.vb
'
' This program is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 2 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program; see the file COPYING. If not, write to the
' Free Software Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.

Private G_Ribbon As Object
Private G_TemplateVersion As String

Private Sub onLoad(rb As Object)
    Debug.Print "Custon ribbon loaded"
    Set CustomRibbonTab.G_Ribbon = rb
    CustomRibbonTab.G_Ribbon.ActivateTab "PowerAuditor"
End Sub

Private Sub RibbonOnChange(control As Object, val)
    Worksheets("PowerAuditor").Range(control.Id).Value2 = val
End Sub

Private Sub isDevMode(control As Object, ByRef enabled)
    enabled = Common.isDevMode()
End Sub

Private Sub getVersion(control As IRibbonControl, ByRef text)
    On Error Resume Next
    text = Range(control.Id).Value2
    Err.Clear
End Sub

Private Sub lastUpdate(control As IRibbonControl, ByRef text)
    Debug.Print "Getting LastUpdate"
    text = Common.trim(IOFile.getOutpoutFromShellCmd(IOFile.getPowerAuditorPath() & "\PowerAuditor_LastUpdateVulndb.bat "))
End Sub

Public Sub invalidAlltext()
    On Error Resume Next
    CustomRibbonTab.G_Ribbon.InvalidateControl "TemplateVersion"
    Err.Clear
End Sub
