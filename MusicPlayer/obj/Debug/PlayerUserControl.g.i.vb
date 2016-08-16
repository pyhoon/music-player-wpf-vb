﻿#ExternalChecksum("..\..\PlayerUserControl.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","D72DFEFE5EF785EB15BBFBFF41F35C0A")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports MusicPlayer
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Forms.Integration
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''PlayerUserControl
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class PlayerUserControl
    Inherits System.Windows.Controls.UserControl
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\PlayerUserControl.xaml",9)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents imgBackground As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\PlayerUserControl.xaml",10)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents lstSongs As System.Windows.Controls.ListBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\PlayerUserControl.xaml",13)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents lstMenu As System.Windows.Controls.ListBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\PlayerUserControl.xaml",20)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents rectPrevious As System.Windows.Shapes.Rectangle
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\PlayerUserControl.xaml",21)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents rectNext As System.Windows.Shapes.Rectangle
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\PlayerUserControl.xaml",22)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents rectMenu As System.Windows.Shapes.Rectangle
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\PlayerUserControl.xaml",23)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents rectPlayPause As System.Windows.Shapes.Rectangle
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\PlayerUserControl.xaml",24)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents MediaElement1 As System.Windows.Controls.MediaElement
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/MusicPlayer;component/playerusercontrol.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\PlayerUserControl.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.imgBackground = CType(target,System.Windows.Controls.Image)
            Return
        End If
        If (connectionId = 2) Then
            Me.lstSongs = CType(target,System.Windows.Controls.ListBox)
            Return
        End If
        If (connectionId = 3) Then
            Me.lstMenu = CType(target,System.Windows.Controls.ListBox)
            Return
        End If
        If (connectionId = 4) Then
            Me.rectPrevious = CType(target,System.Windows.Shapes.Rectangle)
            
            #ExternalSource("..\..\PlayerUserControl.xaml",20)
            AddHandler Me.rectPrevious.MouseDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.OnMouseDownGoPrevious)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 5) Then
            Me.rectNext = CType(target,System.Windows.Shapes.Rectangle)
            
            #ExternalSource("..\..\PlayerUserControl.xaml",21)
            AddHandler Me.rectNext.MouseDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.OnMouseDownGoNext)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 6) Then
            Me.rectMenu = CType(target,System.Windows.Shapes.Rectangle)
            
            #ExternalSource("..\..\PlayerUserControl.xaml",22)
            AddHandler Me.rectMenu.MouseDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.OnMouseDownOpenMenu)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 7) Then
            Me.rectPlayPause = CType(target,System.Windows.Shapes.Rectangle)
            
            #ExternalSource("..\..\PlayerUserControl.xaml",23)
            AddHandler Me.rectPlayPause.MouseDown, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.OnMouseDownPlayPause)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 8) Then
            Me.MediaElement1 = CType(target,System.Windows.Controls.MediaElement)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

