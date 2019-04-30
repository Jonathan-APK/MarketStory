<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panaroma.aspx.cs" Inherits="MarketStory.Panaroma" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 3.2//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <style type='text/css'>
            input[type='text'] {
                width: 400px;
            }
        </style>
        <script type='text/javascript' src="jspanoviewer.js"></script>
        <title></title>
    </head>
        <body onload='popupateSelect()'>
        <form runat="server" id="filechooser">
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/TOP.png" />
            <div align="center">
                <br />
                <asp:Button ID="createBoothButton" runat="server" OnClick="createBoothButton_Click" Text="Create Booth" />
                <br />
                <br />
                <asp:Button ID="manageBoothButton" runat="server" OnClick="manageBoothButton_Click" style="height: 26px" Text="Manage Booth" />
                <br />
                <br />
                <asp:Button ID="viewBooth1Button" runat="server" Text="View Booth 1" />
                <br />
                <br />
                <asp:Button ID="viewBooth2Button" runat="server" Text="View Booth 2" />
        </form>
        <script type="text/javascript">
            var urlElem = document.getElementById('url');
            var urlListElem = document.getElementById('urllist');
            var redirect = document.getElementByID('redirect');
            pv = new JSPanoViewer({
                containerId: "panoContainer",
                //mode        : 51,
                //hFovDst     : 330,
                mode: 1,
                hFovDst: 120,
                hFovSrc: 360,
                cssWidth: '720px',
                cssHeight: '300px'
            });
            var presets = [
                {
                    title: 'Cows in the evening sun',
                    url: 'http://lh5.ggpht.com/_Fel5i-Q8T8g/SYhTM8TVGTI/AAAAAAAACD8/W2zSzjRM39M/100_2851-100_2853.jpg',
                    options: { hFovSrc: 140, hFovDst: 100, mode: 1 }
                },
                {
                    title: 'Parking lot',
                    url: 'http://www.360-vr-tour.com/pano/cajun_palms/crawtown/pano_crawfishtown.jpg',
                    options: { hFovSrc: 360, hFovDst: 300, mode: 51 }
                },
                {
                    title: 'Twin lakes',
                    url: 'http://www.johnfrazee.com/hdr/hdr-pano-converse-lake-sm.jpg',
                    options: { hFovSrc: 360, hFovDst: 140, mode: 1 }
                },
                {
                    title: 'HAHA',
                    url: '../Images/Market/PanoramaBG.png',
                    options: { hFovSrc: 250, hFovDst: 110, mode: 1 }
                }
            ];
            function loadFromPreset(index) {
                if (index >= 0) {
                    var url = presets[index].url;
                    var options = presets[index].options;
                    pv.loadImage(url, options);
                    urlElem.value = url;
                }
            }
            function popupateSelect() {
                for (i in presets) {
                    var option = document.createElement('option');
                    var url = '../Images/Market/PanoramaBG.png';
                    var options = -1;
                    pv.loadImage(url, options);
                    option.value = i;
                    option.innerHTML = presets[i].title;
                    urlListElem.appendChild(option);
                }
            }

            function clickTest() {
                window.location = "BoothUI.aspx?booth=2";
            }
        </script>
        </div>
        <!--img src='img/12-cathedrale-2-ok.jpg' class='panoviewer' /-->
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/BOTTOM.png" />
</body>
</html>
