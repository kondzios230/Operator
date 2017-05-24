using Operator;
using Operator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Test
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
		<div id=folderlabel> folder </div>
		<div id=folder> /PATH/TO/CURRENT/DIRECTORY </div>
		<div id=body>
			<table cellpadding=5>
				<th> Filename
				<th> Filesize
				<th> Filetime
				
				<tr>
				<td>
				<a href=""PATH/TO/FILENAME1"">	
				<b>	FILENAME1</b>
				</a>
				<td align=right> FILESIZE1
				 <td align=right> FILETIME1
				 <td align=right>	<a href=''PATH/TO/FILENAME1?del=1''>		Remove</a>
			</table>
		</div>
	</body>
</html>
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
