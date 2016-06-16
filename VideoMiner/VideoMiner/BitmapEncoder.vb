Option Explicit On
Option Strict On

Public Class BitmapEncoder
    ''' <summary>
    ''' Copies a bitmap into a 1bpp bitmap of the same dimensions, fast
    ''' </summary>
    ''' <param name="b">original bitmap</param>
    ''' <returns>a 1bpp copy of the bitmap</returns>
    Public Shared Function ConvertBitmapTo1bpp(ByVal b As System.Drawing.Bitmap) As System.Drawing.Bitmap
        ' Plan: built into Windows GDI is the ability to convert
        ' bitmaps from one format to another. Most of the time, this
        ' job is actually done by the graphics hardware accelerator card
        ' and so is extremely fast. The rest of the time, the job is done by
        ' very fast native code.
        ' We will call into this GDI functionality from C#. Our plan:
        ' (1) Convert our Bitmap into a GDI hbitmap (ie. copy unmanaged->managed)
        ' (2) Create a GDI monochrome hbitmap
        ' (3) Use GDI "BitBlt" function to copy from hbitmap into monochrome (as above)
        ' (4) Convert the monochrone hbitmap into a Bitmap (ie. copy unmanaged->managed)

        Dim w As Integer = b.Width, h As Integer = b.Height
        Dim hbm As IntPtr = b.GetHbitmap()
        ' this is step (1)
        '
        ' Step (2): create the monochrome bitmap.
        ' "BITMAPINFO" is an interop-struct which we define below.
        ' In GDI terms, it's a BITMAPHEADERINFO followed by an array of two RGBQUADs
        Dim bmi As New BITMAPINFO()
        bmi.biSize = 40
        ' the size of the BITMAPHEADERINFO struct
        bmi.biWidth = w
        bmi.biHeight = h
        bmi.biPlanes = 1
        ' "planes" are confusing. We always use just 1. Read MSDN for more info.
        bmi.biBitCount = CShort(1)
        ' ie. 1bpp or 8bpp
        bmi.biCompression = BI_RGB
        ' ie. the pixels in our RGBQUAD table are stored as RGBs, not palette indexes
        bmi.biSizeImage = CUInt((((w + 7) And &HFFFFFFF8) * h / 8))
        bmi.biXPelsPerMeter = 1000000
        ' not really important
        bmi.biYPelsPerMeter = 1000000
        ' not really important
        ' Now for the colour table.
        Dim ncols As UInteger = CUInt(1) << 1
        ' 2 colours for 1bpp; 256 colours for 8bpp
        bmi.biClrUsed = ncols
        bmi.biClrImportant = ncols
        bmi.cols = New UInteger(255) {}
        ' The structure always has fixed size 256, even if we end up using fewer colours

        bmi.cols(0) = MAKERGB(0, 0, 0)
        bmi.cols(1) = MAKERGB(255, 255, 255)
        ' 
        ' Now create the indexed bitmap "hbm0"
        Dim bits0 As IntPtr
        ' not used for our purposes. It returns a pointer to the raw bits that make up the bitmap.
        Dim hbm0 As IntPtr = CreateDIBSection(IntPtr.Zero, bmi, DIB_RGB_COLORS, bits0, IntPtr.Zero, 0)
        '
        ' Step (3): use GDI's BitBlt function to copy from original hbitmap into monocrhome bitmap
        ' GDI programming is kind of confusing... nb. The GDI equivalent of "Graphics" is called a "DC".
        Dim sdc As IntPtr = GetDC(IntPtr.Zero)
        ' First we obtain the DC for the screen
        ' Next, create a DC for the original hbitmap
        Dim hdc As IntPtr = CreateCompatibleDC(sdc)
        SelectObject(hdc, hbm)
        ' and create a DC for the monochrome hbitmap
        Dim hdc0 As IntPtr = CreateCompatibleDC(sdc)
        SelectObject(hdc0, hbm0)
        ' Now we can do the BitBlt:
        BitBlt(hdc0, 0, 0, w, h, hdc, 0, 0, SRCCOPY)
        ' Step (4): convert this monochrome hbitmap back into a Bitmap:
        Dim b0 As System.Drawing.Bitmap = System.Drawing.Bitmap.FromHbitmap(hbm0)

        DeleteDC(hdc)
        DeleteDC(hdc0)
        ReleaseDC(IntPtr.Zero, sdc)
        DeleteObject(hbm)
        DeleteObject(hbm0)
        Return b0
    End Function

    Private Shared SRCCOPY As Integer = &HCC0020
    Private Shared BI_RGB As UInteger = 0
    Private Shared DIB_RGB_COLORS As UInteger = 0
    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Private Shared Function DeleteObject(ByVal hObject As IntPtr) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Private Shared Function GetDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Private Shared Function CreateCompatibleDC(ByVal hdc As IntPtr) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Private Shared Function ReleaseDC(ByVal hwnd As IntPtr, ByVal hdc As IntPtr) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Private Shared Function DeleteDC(ByVal hdc As IntPtr) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Private Shared Function SelectObject(ByVal hdc As IntPtr, ByVal hgdiobj As IntPtr) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Private Shared Function BitBlt(ByVal hdcDst As IntPtr, ByVal xDst As Integer, ByVal yDst As Integer, ByVal w As Integer, ByVal h As Integer, ByVal hdcSrc As IntPtr, _
     ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal rop As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Private Shared Function CreateDIBSection(ByVal hdc As IntPtr, ByRef bmi As BITMAPINFO, ByVal Usage As UInteger, ByRef bits As IntPtr, ByVal hSection As IntPtr, ByVal dwOffset As UInteger) As IntPtr
    End Function

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)> _
    Private Structure BITMAPINFO
        Public biSize As UInteger
        Public biWidth As Integer, biHeight As Integer
        Public biPlanes As Short, biBitCount As Short
        Public biCompression As UInteger, biSizeImage As UInteger
        Public biXPelsPerMeter As Integer, biYPelsPerMeter As Integer
        Public biClrUsed As UInteger, biClrImportant As UInteger
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=256)> _
        Public cols As UInteger()
    End Structure

    Private Shared Function MAKERGB(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer) As UInteger
        Return CUInt((b And 255)) Or CUInt(((r And 255) << 8)) Or CUInt(((g And 255) << 16))
    End Function
    Private Sub New()

    End Sub
End Class