using Operator;
using Operator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Services
{
    public class CameraMock : ICamera
    {
        public int status=0;

        public Task<string> GetImages()
        {
            return Task.Run(() =>
            {
                var html =
                        @"<html>
<body>
<div id=folderlabel>folder</div>
<div id=folder>/DCIM/PHOTO</div>
<div id=body>
<table cellpadding=5>
<th>Filename
<th>Filesize
<th>Filetime
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101209_001.JPG""><b>0</b></a><td align=right> 165.44 KB<td align=right>2017/05/20 10:12:08
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101209_001.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101214_002.JPG""><b>1</b></a><td align=right> 177.51 KB<td align=right>2017/05/20 10:12:14
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101214_002.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101219_003.JPG""><b>2</b></a><td align=right> 182.12 KB<td align=right>2017/05/20 10:12:18
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101219_003.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101224_004.JPG""><b>3</b></a><td align=right> 134.22 KB<td align=right>2017/05/20 10:12:24
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101224_004.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101209_001.JPG""><b>4</b></a><td align=right> 165.44 KB<td align=right>2017/05/20 10:12:08
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101209_001.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101214_002.JPG""><b>5</b></a><td align=right> 177.51 KB<td align=right>2017/05/20 10:12:14
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101214_002.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101219_003.JPG""><b>6</b></a><td align=right> 182.12 KB<td align=right>2017/05/20 10:12:18
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101219_003.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101224_004.JPG""><b>7</b></a><td align=right> 134.22 KB<td align=right>2017/05/20 10:12:24
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101224_004.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101209_001.JPG""><b>8</b></a><td align=right> 165.44 KB<td align=right>2017/05/20 10:12:08
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101209_001.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101214_002.JPG""><b>9</b></a><td align=right> 177.51 KB<td align=right>2017/05/20 10:12:14
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101214_002.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101219_003.JPG""><b>10</b></a><td align=right> 182.12 KB<td align=right>2017/05/20 10:12:18
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101219_003.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101224_004.JPG""><b>11</b></a><td align=right> 134.22 KB<td align=right>2017/05/20 10:12:24
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101224_004.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101209_001.JPG""><b>12</b></a><td align=right> 165.44 KB<td align=right>2017/05/20 10:12:08
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101209_001.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101214_002.JPG""><b>13</b></a><td align=right> 177.51 KB<td align=right>2017/05/20 10:12:14
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101214_002.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101219_003.JPG""><b>14</b></a><td align=right> 182.12 KB<td align=right>2017/05/20 10:12:18
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101219_003.JPG?del=1"">Remove</a>
<tr><td><a href=""/DCIM/PHOTO/2017_0520_101224_004.JPG""><b>15</b></a><td align=right> 134.22 KB<td align=right>2017/05/20 10:12:24
<td align=right><a href=""/DCIM/PHOTO/2017_0520_101224_004.JPG?del=1"">Remove</a>
";
                return html;

            });
        }

        public Task<string> StartRecording()
        {
            return Task.Run(()=>string.Format(@"<?xml version=""1.0""?><Function><Cmd>2001</Cmd><Status>{0}</Status></Function>",status.ToString()));
        }
    }
}
