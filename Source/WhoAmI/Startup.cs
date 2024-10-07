/*
	This file is part of Who Am I? /L
		© 2024 LisiasT : http://lisias.net <support@lisias.net>
		© 2018-2024 Maja
		© 2016-2018 RealGecko

	Who Am I? /L is licensed as follows:
		* GPL 3.0 : https://www.gnu.org/licenses/gpl-3.0.txt

	Who Am I? /L is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the GNU General Public License 3.0
	along with Who Am I? /L. If not, see <https://www.gnu.org/licenses/>.

*/
using System;
using UnityEngine;

namespace WhoAmI
{
	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	internal class Startup:MonoBehaviour
	{
		private void Start()
		{
			Log.force("Version {0}", Version.Text);
		}
	}
}
