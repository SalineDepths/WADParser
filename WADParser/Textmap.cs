using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WADParser
{
    public abstract class TextmapEntry
    {
        public abstract string Write();
    }

    public class ThingEntry : TextmapEntry
    {
        public int id = 0;
        public float x;
        public float y;

        public float height = 0.0f;
        public int angle = 0;
        public int type;

        public bool skill1 = false;
        public bool skill2 = false;
        public bool skill3 = false;
        public bool skill4 = false;
        public bool skill5 = false;


        public bool ambush = false;
        public bool single = false;
        public bool dm = false;
        public bool coop = false;

        public bool friend = false;

        public bool dormant = false;

        public bool class1 = false;
        public bool class2 = false;
        public bool class3 = false;
        public bool class4 = false;

        public bool standing = false;
        public bool strifeally = false;
        public bool translucent = false;
        public bool invisible = false;

        public int special = 0;
        public int arg0 = 0;
        public int arg1 = 0;
        public int arg2 = 0;
        public int arg3 = 0;
        public int arg4 = 0;

        public string comment = "";

        //zdoom
        public bool skill6 = false;
        public bool skill7 = false;
        public bool skill8 = false;
        public bool skill9 = false;
        public bool skill10 = false;
        public bool skill11 = false;
        public bool skill12 = false;
        public bool skill13 = false;
        public bool skill14 = false;
        public bool skill15 = false;
        public bool skill16 = false;

        public bool class5 = false;
        public bool class6 = false;
        public bool class7 = false;
        public bool class8 = false;
        public bool class9 = false;
        public bool class10 = false;
        public bool class11 = false;
        public bool class12 = false;
        public bool class13 = false;
        public bool class14 = false;
        public bool class15 = false;
        public bool class16 = false;

        public int conversation = 0;
        public bool countsecret = false;
        public string arg0str = "";
        public float gravity = 1.0f;

        public int health = -1;

        public string renderstyle = "";
        public int fillcolor = 0x000000;
        public float alpha = 1.0f;
        public int score = 0;
        public int pitch = 0;
        public int roll = 0;
        public float scalex = 0.0f;
        public float scaley = 0.0f;
        public float scale = 0.0f;
        public int floatbobphase = -1;

        public Dictionary<string, string> uservars = new Dictionary<string, string>();

        public ThingEntry(byte[] bytes)
        {
            string converted = Encoding.Default.GetString(bytes);
            if (converted.Length > 0)
            {
                Setup(new List<string>(converted.Split('\n')));
            }
        }

        public ThingEntry(List<string> linesIn)
        {
            Setup(linesIn);
        }


        public override string Write()
        {
            string output = string.Empty;

            if (id != 0) output += "id = " + id.ToString() + ';';
            output += "\nx = " + x.ToString() + ';';
            output += "\ny = " + y.ToString() + ';';

            if (height != 0.0f) output += "\nheight = " + height.ToString() + ';';
            if (angle != 0) output += "\nangle = " + angle.ToString() + ';';
            output += "\ntype = " + type.ToString() + ';';

            if (skill1 != false) output += "\nskill1 = " + skill1.ToString() + ';';
            if (skill2 != false) output += "\nskill2 = " + skill2.ToString() + ';';
            if (skill3 != false) output += "\nskill3 = " + skill3.ToString() + ';';
            if (skill4 != false) output += "\nskill4 = " + skill4.ToString() + ';';
            if (skill5 != false) output += "\nskill5 = " + skill5.ToString() + ';';

            if (ambush != false) output += "\nambush = " + ambush.ToString() + ';';
            if (single != false) output += "\nsingle = " + single.ToString() + ';';
            if (dm != false) output += "\ndm = " + dm.ToString() + ';';
            if (coop != false) output += "\ncoop = " + coop.ToString() + ';';

            if (friend != false) output += "\nfriend = " + friend.ToString() + ';';

            if (dormant != false) output += "\ndormant = " + dormant.ToString() + ';';

            if (class1 != false) output += "\nclass1 = " + class1.ToString() + ';';
            if (class2 != false) output += "\nclass2 = " + class2.ToString() + ';';
            if (class3 != false) output += "\nclass3 = " + class3.ToString() + ';';
            if (class4 != false) output += "\nclass4 = " + class4.ToString() + ';';

            if (standing != false) output += "\nstanding = " + standing.ToString() + ';';
            if (strifeally != false) output += "\nstrifeally = " + strifeally.ToString() + ';';
            if (translucent != false) output += "\ntranslucent = " + translucent.ToString() + ';';
            if (invisible != false) output += "\ninvisible = " + invisible.ToString() + ';';

            if (special != 0) output += "\nspecial = " + special.ToString() + ';';
            if (arg0 != 0) output += "\narg0 = " + arg0.ToString() + ';';
            if (arg1 != 0) output += "\narg1 = " + arg1.ToString() + ';';
            if (arg2 != 0) output += "\narg2 = " + arg2.ToString() + ';';
            if (arg3 != 0) output += "\narg3 = " + arg3.ToString() + ';';
            if (arg4 != 0) output += "\narg4 = " + arg4.ToString() + ';';

            if (comment != "") output += "\ncomment = " + comment.ToString() + ';';

            if (skill6 != false) output += "\nskill6 = " + skill6.ToString() + ';';
            if (skill7 != false) output += "\nskill7 = " + skill7.ToString() + ';';
            if (skill8 != false) output += "\nskill8 = " + skill8.ToString() + ';';
            if (skill9 != false) output += "\nskill9 = " + skill9.ToString() + ';';
            if (skill10 != false) output += "\nskill10 = " + skill10.ToString() + ';';
            if (skill11 != false) output += "\nskill11 = " + skill11.ToString() + ';';
            if (skill12 != false) output += "\nskill12 = " + skill12.ToString() + ';';
            if (skill13 != false) output += "\nskill13 = " + skill13.ToString() + ';';
            if (skill14 != false) output += "\nskill14 = " + skill14.ToString() + ';';
            if (skill15 != false) output += "\nskill15 = " + skill15.ToString() + ';';
            if (skill16 != false) output += "\nskill16 = " + skill16.ToString() + ';';

            if (class5 != false) output += "\nclass5 = " + class5.ToString() + ';';
            if (class6 != false) output += "\nclass6 = " + class6.ToString() + ';';
            if (class7 != false) output += "\nclass7 = " + class7.ToString() + ';';
            if (class8 != false) output += "\nclass8 = " + class8.ToString() + ';';
            if (class9 != false) output += "\nclass9 = " + class9.ToString() + ';';
            if (class10 != false) output += "\nclass10 = " + class10.ToString() + ';';
            if (class11 != false) output += "\nclass11 = " + class11.ToString() + ';';
            if (class12 != false) output += "\nclass12 = " + class12.ToString() + ';';
            if (class13 != false) output += "\nclass13 = " + class13.ToString() + ';';
            if (class14 != false) output += "\nclass14 = " + class14.ToString() + ';';
            if (class15 != false) output += "\nclass15 = " + class15.ToString() + ';';
            if (class16 != false) output += "\nclass16 = " + class16.ToString() + ';';

            if (conversation != 0) output += "\nconversation = " + conversation.ToString() + ';';
            if (countsecret != false) output += "\ncountsecret = " + countsecret.ToString() + ';';
            if (arg0str != "") output += "\narg0str = " + arg0str.ToString() + ';';
            if (gravity != 1.0f) output += "\ngravity = " + gravity.ToString() + ';';

            if (health != -1) output += "\nhealth = " + health.ToString() + ';';

            if (renderstyle != "") output += "\nrenderstyle = " + renderstyle.ToString() + ';';
            if (fillcolor != 0x000000) output += "\nfillcolor = " + fillcolor.ToString() + ';';
            if (alpha != 1.0f) output += "\nalpha = " + alpha.ToString() + ';';
            if (score != 0) output += "\nscore = " + score.ToString() + ';';
            if (pitch != 0) output += "\npitch = " + pitch.ToString() + ';';
            if (roll != 0) output += "\nroll = " + roll.ToString() + ';';
            if (scalex != 0.0f) output += "\nscalex = " + scalex.ToString() + ';';
            if (scaley != 0.0f) output += "\nscaley = " + scaley.ToString() + ';';
            if (scale != 0.0f) output += "\nscale = " + scale.ToString() + ';';
            if (floatbobphase != -1) output += "\nfloatbobphase = " + floatbobphase.ToString() + ';';

            foreach (var entry in uservars) output += '\n' + entry.Key + " = " + entry.Value + ';';

            return output;
        }

        private void Setup(List<string> linesIn)
        {
            foreach (string line in linesIn)
            {
                string[] chunks = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);

                if (chunks.Length == 2)
                {
                    switch (chunks[0])
                    {
                        case "id":
                            id = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "x":
                            x = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "y":
                            y = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "height":
                            height = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "angle":
                            angle = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "type":
                            type = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill1":
                            skill1 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill2":
                            skill2 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill3":
                            skill3 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill4":
                            skill4 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill5":
                            skill5 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "ambush":
                            ambush = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "single":
                            single = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "dm":
                            dm = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "coop":
                            coop = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "friend":
                            friend = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "dormant":
                            dormant = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class1":
                            class1 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class2":
                            class2 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class3":
                            class3 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class4":
                            class4 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "standing":
                            standing = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "strifeally":
                            strifeally = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "translucent":
                            translucent = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "invisible":
                            invisible = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "special":
                            special = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg0":
                            arg0 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg1":
                            arg1 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg2":
                            arg2 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg3":
                            arg3 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg4":
                            arg4 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "comment":
                            comment = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "skill6":
                            skill6 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill7":
                            skill7 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill8":
                            skill8 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill9":
                            skill9 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill10":
                            skill10 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill11":
                            skill11 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill12":
                            skill12 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill13":
                            skill13 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill14":
                            skill14 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill15":
                            skill15 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "skill16":
                            skill16 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class5":
                            class5 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class6":
                            class6 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class7":
                            class7 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class8":
                            class8 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class9":
                            class9 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class10":
                            class10 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class11":
                            class11 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class12":
                            class12 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class13":
                            class13 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class14":
                            class14 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class15":
                            class15 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "class16":
                            class16 = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "conversation":
                            conversation = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "countsecret":
                            countsecret = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg0str":
                            arg0str = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "gravity":
                            gravity = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "health":
                            health = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "renderstyle":
                            renderstyle = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "fillcolor":
                            fillcolor = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "alpha":
                            alpha = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "score":
                            score = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "pitch":
                            pitch = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "roll":
                            roll = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "scalex":
                            scalex = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "scaley":
                            scaley = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "scale":
                            scale = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "floatbobphase":
                            floatbobphase = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        default:
                            uservars.Add(chunks[0], chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                    }
                }
            }
        }
    }

    public class LinedefEntry : TextmapEntry
    {
        public int id = -1;

        public int v1;
        public int v2;

        public bool blocking = false;
        public bool blockmonsters = false;
        public bool twosided = false;
        public bool dontpegtop = false;
        public bool dontpegbottom = false;
        public bool secret = false;
        public bool blocksound = false;
        public bool dontdraw = false;
        public bool mapped = false;

        public bool passuse = false;

        public bool playercross = false;
        public bool playeruse = false;
        public bool monstercross = false;
        public bool monsteruse = false;
        public bool impact = false;
        public bool playerpush = false;
        public bool monsterpush = false;
        public bool missilecross = false;
        public bool repeatspecial = false;

        public int special = 0;
        public int arg0 = 0;
        public int arg1 = 0;
        public int arg2 = 0;
        public int arg3 = 0;
        public int arg4 = 0;

        public int sidefront;
        public int sideback = -1;

        public string comment = "";

        //zdoom
        public float alpha = 1.0f;
        public string renderstyle = "";

        public bool playeruseback = false;
        public bool anycross = false;
        public bool monsteractivate = false;
        public bool blockplayers = false;
        public bool blockeverything = false;
        public bool firstsideonly = false;
        public bool zoneboundary = false;
        public bool clipmidtex = false;
        public bool wrapmidtex = false;
        public bool midtex3d = false;
        public bool midtex3dimpassible = false;

        public bool checkswitchrange = false;
        public bool blockprojectiles = false;
        public bool blockuse = false;
        public bool blocksight = false;
        public bool blockhitscan = false;
        public int locknumber = 0;
        public string arg0str = "";
        public List<string> moreids = new List<string>();

        public bool transparent = false;

        public Dictionary<string, string> uservars = new Dictionary<string, string>();

        public LinedefEntry(byte[] bytes)
        {
            string converted = Encoding.Default.GetString(bytes);
            if (converted.Length > 0)
            {
                Setup(new List<string>(converted.Split('\n')));
            }
        }

        public LinedefEntry(List<string> linesIn)
        {
            Setup(linesIn);
        }

        public override string Write()
        {
            string output = string.Empty;

            if (id != -1) output += "id = " + id.ToString() + ';';

            output += "\nv1 = " + v1.ToString() + ';';
            output += "\nv2 = " + v2.ToString() + ';';

            if (blocking != false) output += "\nblocking = " + blocking.ToString() + ';';
            if (blockmonsters != false) output += "\nblockmonsters = " + blockmonsters.ToString() + ';';
            if (twosided != false) output += "\ntwosided = " + twosided.ToString() + ';';
            if (dontpegtop != false) output += "\ndontpegtop = " + dontpegtop.ToString() + ';';
            if (dontpegbottom != false) output += "\ndontpegbottom = " + dontpegbottom.ToString() + ';';
            if (secret != false) output += "\nsecret = " + secret.ToString() + ';';
            if (blocksound != false) output += "\nblocksound = " + blocksound.ToString() + ';';
            if (dontdraw != false) output += "\ndontdraw = " + dontdraw.ToString() + ';';
            if (mapped != false) output += "\nmapped = " + mapped.ToString() + ';';

            if (passuse != false) output += "\npassuse = " + passuse.ToString() + ';';

            if (playercross != false) output += "\nplayercross = " + playercross.ToString() + ';';
            if (playeruse != false) output += "\nplayeruse = " + playeruse.ToString() + ';';
            if (monstercross != false) output += "\nmonstercross = " + monstercross.ToString() + ';';
            if (monsteruse != false) output += "\nmonsteruse = " + monsteruse.ToString() + ';';
            if (impact != false) output += "\nimpact = " + impact.ToString() + ';';
            if (playerpush != false) output += "\nplayerpush = " + playerpush.ToString() + ';';
            if (monsterpush != false) output += "\nmonsterpush = " + monsterpush.ToString() + ';';
            if (missilecross != false) output += "\nmissilecross = " + missilecross.ToString() + ';';
            if (repeatspecial != false) output += "\nrepeatspecial = " + repeatspecial.ToString() + ';';

            if (special != 0) output += "\nspecial = " + special.ToString() + ';';
            if (arg0 != 0) output += "\narg0 = " + arg0.ToString() + ';';
            if (arg1 != 0) output += "\narg1 = " + arg1.ToString() + ';';
            if (arg2 != 0) output += "\narg2 = " + arg2.ToString() + ';';
            if (arg3 != 0) output += "\narg3 = " + arg3.ToString() + ';';
            if (arg4 != 0) output += "\narg4 = " + arg4.ToString() + ';';

            output += "\nsidefront = " + sidefront.ToString() + ';';
            if (sideback != -1) output += "\nsideback = " + sideback.ToString() + ';';

            if (comment != "") output += "\ncomment = " + comment.ToString() + ';';

            if (alpha != 1.0f) output += "\nalpha = " + alpha.ToString() + ';';
            if (renderstyle != "") output += "\nrenderstyle = " + renderstyle.ToString() + ';';

            if (playeruseback != false) output += "\nplayeruseback = " + playeruseback.ToString() + ';';
            if (anycross != false) output += "\nanycross = " + anycross.ToString() + ';';
            if (monsteractivate != false) output += "\nmonsteractivate = " + monsteractivate.ToString() + ';';
            if (blockplayers != false) output += "\nblockplayers = " + blockplayers.ToString() + ';';
            if (blockeverything != false) output += "\nblockeverything = " + blockeverything.ToString() + ';';
            if (firstsideonly != false) output += "\nfirstsideonly = " + firstsideonly.ToString() + ';';
            if (zoneboundary != false) output += "\nzoneboundary = " + zoneboundary.ToString() + ';';
            if (clipmidtex != false) output += "\nclipmidtex = " + clipmidtex.ToString() + ';';
            if (wrapmidtex != false) output += "\nwrapmidtex = " + wrapmidtex.ToString() + ';';
            if (midtex3d != false) output += "\nmidtex3d = " + midtex3d.ToString() + ';';
            if (midtex3dimpassible != false) output += "\nmidtex3dimpassible = " + midtex3dimpassible.ToString() + ';';

            if (checkswitchrange != false) output += "\ncheckswitchrange = " + checkswitchrange.ToString() + ';';
            if (blockprojectiles != false) output += "\nblockprojectiles = " + blockprojectiles.ToString() + ';';
            if (blockuse != false) output += "\nblockuse = " + blockuse.ToString() + ';';
            if (blocksight != false) output += "\nblocksight = " + blocksight.ToString() + ';';
            if (blockhitscan != false) output += "\nblockhitscan = " + blockhitscan.ToString() + ';';
            if (locknumber != 0) output += "\nlocknumber = " + locknumber.ToString() + ';';
            if (arg0str != "") output += "\narg0str = " + arg0str.ToString() + ';';
            if (moreids.Count > 0) output += "\nmoreids = " + string.Join(" ", moreids) + ';';

            if (transparent != false) output += "\ntransparent = " + transparent.ToString() + ';';

            foreach (var entry in uservars) output += '\n' + entry.Key + " = " + entry.Value + ';';

            return output;
        }

        private void Setup(List<string> linesIn)
        {
            foreach (string line in linesIn)
            {
                string[] chunks = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);

                if (chunks.Length == 2)
                {
                    switch (chunks[0])
                    {
                        case "id":
                            id = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "v1":
                            v1 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "v2":
                            v2 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "blocking":
                            blocking = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "blockmonsters":
                            blockmonsters = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "twosided":
                            twosided = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "dontpegtop":
                            dontpegtop = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "dontpegbottom":
                            dontpegbottom = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "secret":
                            secret = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "blocksound":
                            blocksound = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "dontdraw":
                            dontdraw = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "mapped":
                            mapped = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "passuse":
                            passuse = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "playercross":
                            playercross = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "playeruse":
                            playeruse = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "monstercross":
                            monstercross = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "monsteruse":
                            monsteruse = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "impact":
                            impact = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "playerpush":
                            playerpush = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "monsterpush":
                            monsterpush = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "missilecross":
                            missilecross = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "repeatspecial":
                            repeatspecial = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "special":
                            special = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg0":
                            arg0 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg1":
                            arg1 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg2":
                            arg2 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg3":
                            arg3 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg4":
                            arg4 = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "sidefront":
                            sidefront = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "sideback":
                            sideback = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "comment":
                            comment = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "alpha":
                            alpha = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "renderstyle":
                            renderstyle = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "playeruseback":
                            playeruseback = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "anycross":
                            anycross = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "monsteractivate":
                            monsteractivate = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "blockplayers":
                            blockplayers = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "blockeverything":
                            blockeverything = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "firstsideonly":
                            firstsideonly = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "zoneboundary":
                            zoneboundary = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "clipmidtex":
                            clipmidtex = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "wrapmidtex":
                            wrapmidtex = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "midtex3d":
                            midtex3d = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "midtex3dimpassible":
                            midtex3dimpassible = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "checkswitchrange":
                            checkswitchrange = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "blockprojectiles":
                            blockprojectiles = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "blockuse":
                            blockuse = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "blocksight":
                            blocksight = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "blockhitscan":
                            blockhitscan = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "locknumber":
                            locknumber = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "arg0str":
                            arg0str = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "transparent":
                            transparent = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "moreids":
                            string[] moreIdArray = chunks[1].Substring(0, chunks[1].Length - 2).Split(' ');
                            moreids = new List<string>(moreIdArray);
                            break;
                        default:
                            uservars.Add(chunks[0], chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                    }
                }
            }
        }
    }

    public class SidedefEntry : TextmapEntry
    {
        public int offsetx = 0;
        public int offsety = 0;

        public string texturetop = "-";
        public string texturebottom = "-";
        public string texturemiddle = "-";

        public int sector;

        public string comment = "";

        //zdoom
        public float scalex_top = 1.0f;
        public float scaley_top = 1.0f;
        public float scalex_mid = 1.0f;
        public float scaley_mid = 1.0f;
        public float scalex_bottom = 1.0f;
        public float scaley_bottom = 1.0f;
        public float offsetx_top = 0.0f;
        public float offsety_top = 0.0f;
        public float offsetx_mid = 0.0f;
        public float offsety_mid = 0.0f;
        public float offsetx_bottom = 0.0f;
        public float offsety_bottom = 0.0f;
        public int light = 0;
        public bool lightabsolute = false;
        public bool lightfog = false;
        public bool nofakecontrast = false;
        public bool clipmidtex = false;
        public bool wrapmidtex = false;
        public bool nodecal = false;

        public Dictionary<string, string> uservars = new Dictionary<string, string>();

        public SidedefEntry(byte[] bytes)
        {
            string converted = Encoding.Default.GetString(bytes);
            if (converted.Length > 0)
            {
                Setup(new List<string>(converted.Split('\n')));
            }
        }

        public SidedefEntry(List<string> linesIn)
        {
            Setup(linesIn);
        }

        public override string Write()
        {
            string output = string.Empty;

            if (offsetx != 0) output += "offsetx = " + offsetx.ToString() + ';';
            if (offsety != 0) output += "\noffsety = " + offsety.ToString() + ';';

            if (texturetop != "-") output += "\ntexturetop = " + texturetop.ToString() + ';';
            if (texturebottom != "-") output += "\ntexturebottom = " + texturebottom.ToString() + ';';
            if (texturemiddle != "-") output += "\ntexturemiddle = " + texturemiddle.ToString() + ';';

            output += "\nsector = " + sector.ToString() + ';';

            if (comment != "") output += "\ncomment = " + comment.ToString() + ';';

            if (scalex_top != 1.0f) output += "\nscalex_top = " + scalex_top.ToString() + ';';
            if (scaley_top != 1.0f) output += "\nscaley_top = " + scaley_top.ToString() + ';';
            if (scalex_mid != 1.0f) output += "\nscalex_mid = " + scalex_mid.ToString() + ';';
            if (scaley_mid != 1.0f) output += "\nscaley_mid = " + scaley_mid.ToString() + ';';
            if (scalex_bottom != 1.0f) output += "\nscalex_bottom = " + scalex_bottom.ToString() + ';';
            if (scaley_bottom != 1.0f) output += "\nscaley_bottom = " + scaley_bottom.ToString() + ';';
            if (offsetx_top != 0.0f) output += "\noffsetx_top = " + offsetx_top.ToString() + ';';
            if (offsety_top != 0.0f) output += "\noffsety_top = " + offsety_top.ToString() + ';';
            if (offsetx_mid != 0.0f) output += "\noffsetx_mid = " + offsetx_mid.ToString() + ';';
            if (offsety_mid != 0.0f) output += "\noffsety_mid = " + offsety_mid.ToString() + ';';
            if (offsetx_bottom != 0.0f) output += "\noffsetx_bottom = " + offsetx_bottom.ToString() + ';';
            if (offsety_bottom != 0.0f) output += "\noffsety_bottom = " + offsety_bottom.ToString() + ';';
            if (light != 0) output += "\nlight = " + light.ToString() + ';';
            if (lightabsolute != false) output += "\nlightabsolute = " + lightabsolute.ToString() + ';';
            if (lightfog != false) output += "\nlightfog = " + lightfog.ToString() + ';';
            if (nofakecontrast != false) output += "\nnofakecontrast = " + nofakecontrast.ToString() + ';';
            if (clipmidtex != false) output += "\nclipmidtex = " + clipmidtex.ToString() + ';';
            if (wrapmidtex != false) output += "\nwrapmidtex = " + wrapmidtex.ToString() + ';';
            if (nodecal != false) output += "\nnodecal = " + nodecal.ToString() + ';';

            foreach (var entry in uservars) output += '\n' + entry.Key + " = " + entry.Value + ';';

            return output;
        }

        private void Setup(List<string> linesIn)
        {
            foreach (string line in linesIn)
            {
                string[] chunks = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);

                if (chunks.Length == 2)
                {
                    switch (chunks[0])
                    {
                        case "offsetx":
                            offsetx = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "offsety":
                            offsety = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "texturetop":
                            texturetop = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "texturebottom":
                            texturebottom = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "texturemiddle":
                            texturemiddle = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "sector":
                            sector = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "comment":
                            comment = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "scalex_top":
                            scalex_top = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "scaley_top":
                            scaley_top = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "scalex_mid":
                            scalex_mid = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "scaley_mid":
                            scaley_mid = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "scalex_bottom":
                            scalex_bottom = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "scaley_bottom":
                            scaley_bottom = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "offsetx_top":
                            offsetx_top = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "offsety_top":
                            offsety_top = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "offsetx_mid":
                            offsetx_mid = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "offsety_mid":
                            offsety_mid = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "offsetx_bottom":
                            offsetx_bottom = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "offsety_bottom":
                            offsety_bottom = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "light":
                            light = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "lightabsolute":
                            lightabsolute = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "lightfog":
                            lightfog = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "nofakecontrast":
                            nofakecontrast = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "clipmidtex":
                            clipmidtex = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "wrapmidtex":
                            wrapmidtex = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "nodecal":
                            nodecal = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                    }
                }
            }
        }
    }

    public class VertexEntry : TextmapEntry
    {
        public float x;
        public float y;

        //zdoom
        public float zfloor;
        public float zceiling;

        public Dictionary<string, string> uservars = new Dictionary<string, string>();

        public VertexEntry(byte[] bytes)
        {
            string converted = Encoding.Default.GetString(bytes);
            if (converted.Length > 0)
            {
                Setup(new List<string>(converted.Split('\n')));
            }
        }

        public VertexEntry(List<string> linesIn)
        {
            Setup(linesIn);
        }

        public override string Write()
        {
            string output = string.Empty;
            output += "x = " + x.ToString() + ';';
            output += "\ny = " + y.ToString() + ';';
            output += "\nzfloor = " + zfloor.ToString() + ';';
            output += "\nzceiling = " + zceiling.ToString() + ';';
            foreach (var entry in uservars) output += '\n' + entry.Key + " = " + entry.Value + ';';
            return output;
        }

        private void Setup(List<string> linesIn)
        {
            foreach (string line in linesIn)
            {
                string[] chunks = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);

                if (chunks.Length == 2)
                {
                    switch (chunks[0])
                    {
                        case "x":
                            x = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "y":
                            y = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "zfloor":
                            zfloor = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "zceiling":
                            zceiling = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        default:
                            uservars.Add(chunks[0], chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                    }
                }
            }
        }
    }

    public class SectorEntry : TextmapEntry
    {
        public int heightfloor = 0;
        public int heightceiling = 0;

        public string texturefloor;
        public string textureceiling;

        public int lightlevel = 160;

        public int special = 0;
        public int id = 0;

        public string comment = "";

        //zdoom
        public float xpanningfloor = 0.0f;
        public float ypanningfloor = 0.0f;
        public float xpanningceiling = 0.0f;
        public float ypanningceiling = 0.0f;
        public float xscalefloor = 1.0f;
        public float yscalefloor = 1.0f;
        public float xscaleceiling = 1.0f;
        public float yscaleceiling = 1.0f;
        public float rotationfloor = 0.0f;
        public float rotationceiling = 0.0f;
        public float ceilingplane_a = 0.0f;
        public float ceilingplane_b = 0.0f;
        public float ceilingplane_c = 0.0f;
        public float ceilingplane_d = 0.0f;
        public float floorplane_a = 0.0f;
        public float floorplane_b = 0.0f;
        public float floorplane_c = 0.0f;
        public float floorplane_d = 0.0f;
        public int lightfloor = 0;
        public int lightceiling = 0;
        public bool lightfloorabsolute = false;
        public bool lightceilingabsolute = false;
        public float alphafloor = 1.0f;
        public float alphaceiling = 1.0f;
        public string renderstylefloor = "translucent";
        public string renderstyleceiling = "translucent";
        public float gravity = 1.0f;
        public int lightcolor = 0xffffff;
        public int fadecolor = 0x000000;
        public float desaturation = 0;
        public bool silent = false;
        public bool nofallingdamage = false;
        public bool dropactors = false;
        public bool norespawn = false;
        public string soundsequence = "";
        public bool hidden = false;
        public bool waterzone = false;
        public List<string> moreids = new List<string>();
        public int damageamount = 0;
        public string damagetype = "None";
        public int damageinterval = 32;
        public int leakiness = 0;
        public bool damageterraineffect = false;
        public string floorterrain = "";
        public string ceilingterrain = "";

        public bool portal_ceil_blocksound = false;
        public bool portal_ceil_disabled = false;
        public bool portal_ceil_nopass = false;
        public bool portal_ceil_norender = false;
        public string portal_ceil_overlaytype = "translucent";
        public bool portal_floor_blocksound = false;
        public bool portal_floor_disabled = false;
        public bool portal_floor_nopass = false;
        public bool portal_floor_norender = false;
        public string portal_floor_overlaytype = "translucent";

        public Dictionary<string, string> uservars = new Dictionary<string, string>();

        public SectorEntry(byte[] bytes)
        {
            string converted = Encoding.Default.GetString(bytes);
            if (converted.Length > 0)
            {
                Setup(new List<string>(converted.Split('\n')));
            }
        }

        public SectorEntry(List<string> linesIn)
        {
            Setup(linesIn);
        }

        public override string Write()
        {
            string output = string.Empty;

            if (heightfloor != 0) output += "heightfloor = " + heightfloor.ToString() + ';';
            if (heightceiling != 0) output += "\nheightceiling = " + heightceiling.ToString() + ';';
            output += "\ntexturefloor = " + texturefloor.ToString() + ';';
            output += "\ntextureceiling = " + textureceiling.ToString() + ';';

            if (lightlevel != 160) output += "\nlightlevel = " + lightlevel.ToString() + ';';

            if (special != 0) output += "\nspecial = " + special.ToString() + ';';
            if (id != 0) output += "\nid = " + id.ToString() + ';';

            if (comment != "") output += "\ncomment = " + comment.ToString() + ';';

            if (xpanningfloor != 0.0f) output += "\nxpanningfloor = " + xpanningfloor.ToString() + ';';
            if (ypanningfloor != 0.0f) output += "\nypanningfloor = " + ypanningfloor.ToString() + ';';
            if (xpanningceiling != 0.0f) output += "\nxpanningceiling = " + xpanningceiling.ToString() + ';';
            if (ypanningceiling != 0.0f) output += "\nypanningceiling = " + ypanningceiling.ToString() + ';';
            if (xscalefloor != 1.0f) output += "\nxscalefloor = " + xscalefloor.ToString() + ';';
            if (yscalefloor != 1.0f) output += "\nyscalefloor = " + yscalefloor.ToString() + ';';
            if (xscaleceiling != 1.0f) output += "\nxscaleceiling = " + xscaleceiling.ToString() + ';';
            if (yscaleceiling != 1.0f) output += "\nyscaleceiling = " + yscaleceiling.ToString() + ';';
            if (rotationfloor != 0.0f) output += "\nrotationfloor = " + rotationfloor.ToString() + ';';
            if (rotationceiling != 0.0f) output += "\nrotationceiling = " + rotationceiling.ToString() + ';';
            if (ceilingplane_a != 0.0f) output += "\nceilingplane_a = " + ceilingplane_a.ToString() + ';';
            if (ceilingplane_b != 0.0f) output += "\nceilingplane_b = " + ceilingplane_b.ToString() + ';';
            if (ceilingplane_c != 0.0f) output += "\nceilingplane_c = " + ceilingplane_c.ToString() + ';';
            if (ceilingplane_d != 0.0f) output += "\nceilingplane_d = " + ceilingplane_d.ToString() + ';';
            if (floorplane_a != 0.0f) output += "\nfloorplane_a = " + floorplane_a.ToString() + ';';
            if (floorplane_b != 0.0f) output += "\nfloorplane_b = " + floorplane_b.ToString() + ';';
            if (floorplane_c != 0.0f) output += "\nfloorplane_c = " + floorplane_c.ToString() + ';';
            if (floorplane_d != 0.0f) output += "\nfloorplane_d = " + floorplane_d.ToString() + ';';
            if (lightfloor != 0) output += "\nlightfloor = " + lightfloor.ToString() + ';';
            if (lightceiling != 0) output += "\nlightceiling = " + lightceiling.ToString() + ';';
            if (lightfloorabsolute != false) output += "\nlightfloorabsolute = " + lightfloorabsolute.ToString() + ';';
            if (lightceilingabsolute != false) output += "\nlightceilingabsolute = " + lightceilingabsolute.ToString() + ';';
            if (alphafloor != 1.0f) output += "\nalphafloor = " + alphafloor.ToString() + ';';
            if (alphaceiling != 1.0f) output += "\nalphaceiling = " + alphaceiling.ToString() + ';';
            if (renderstylefloor != "translucent") output += "\nrenderstylefloor = " + renderstylefloor.ToString() + ';';
            if (renderstyleceiling != "translucent") output += "\nrenderstyleceiling = " + renderstyleceiling.ToString() + ';';
            if (gravity != 1.0f) output += "\ngravity = " + gravity.ToString() + ';';
            if (lightcolor != 0xffffff) output += "\nlightcolor = " + lightcolor.ToString() + ';';
            if (fadecolor != 0x000000) output += "\nfadecolor = " + fadecolor.ToString() + ';';
            if (desaturation != 0) output += "\ndesaturation = " + desaturation.ToString() + ';';
            if (silent != false) output += "\nsilent = " + silent.ToString() + ';';
            if (nofallingdamage != false) output += "\nnofallingdamage = " + nofallingdamage.ToString() + ';';
            if (dropactors != false) output += "\ndropactors = " + dropactors.ToString() + ';';
            if (norespawn != false) output += "\nnorespawn = " + norespawn.ToString() + ';';
            if (soundsequence != "") output += "\nsoundsequence = " + soundsequence.ToString() + ';';
            if (hidden != false) output += "\nhidden = " + hidden.ToString() + ';';
            if (waterzone != false) output += "\nwaterzone = " + waterzone.ToString() + ';';
            if (moreids.Count > 0) output += "\nmoreids = " + string.Join(" ", moreids) + ';';
            if (damageamount != 0) output += "\ndamageamount = " + damageamount.ToString() + ';';
            if (damagetype != "None") output += "\ndamagetype = " + damagetype.ToString() + ';';
            if (damageinterval != 32) output += "\ndamageinterval = " + damageinterval.ToString() + ';';
            if (leakiness != 0) output += "\nleakiness = " + leakiness.ToString() + ';';
            if (damageterraineffect != false) output += "\ndamageterraineffect = " + damageterraineffect.ToString() + ';';
            if (floorterrain != "") output += "\nfloorterrain = " + floorterrain.ToString() + ';';
            if (ceilingterrain != "") output += "\nceilingterrain = " + ceilingterrain.ToString() + ';';

            if (portal_ceil_blocksound != false) output += "\nportal_ceil_blocksound = " + portal_ceil_blocksound.ToString() + ';';
            if (portal_ceil_disabled != false) output += "\nportal_ceil_disabled = " + portal_ceil_disabled.ToString() + ';';
            if (portal_ceil_nopass != false) output += "\nportal_ceil_nopass = " + portal_ceil_nopass.ToString() + ';';
            if (portal_ceil_norender != false) output += "\nportal_ceil_norender = " + portal_ceil_norender.ToString() + ';';
            if (portal_ceil_overlaytype != "translucent") output += "\nportal_ceil_overlaytype = " + portal_ceil_overlaytype.ToString() + ';';
            if (portal_floor_blocksound != false) output += "\nportal_floor_blocksound = " + portal_floor_blocksound.ToString() + ';';
            if (portal_floor_disabled != false) output += "\nportal_floor_disabled = " + portal_floor_disabled.ToString() + ';';
            if (portal_floor_nopass != false) output += "\nportal_floor_nopass = " + portal_floor_nopass.ToString() + ';';
            if (portal_floor_norender != false) output += "\nportal_floor_norender = " + portal_floor_norender.ToString() + ';';
            if (portal_floor_overlaytype != "translucent") output += "\nportal_floor_overlaytype = " + portal_floor_overlaytype.ToString() + ';';

            foreach (var entry in uservars) output += '\n' + entry.Key + " = " + entry.Value + ';';
            return output;
        }

        private void Setup(List<string> linesIn) //god has no more forgiveness
        {
            foreach (string line in linesIn)
            {
                string[] chunks = line.Split(new string[] { " = " }, StringSplitOptions.RemoveEmptyEntries);

                if (chunks.Length == 2)
                {
                    switch (chunks[0])
                    {
                        case "heightfloor":
                            heightfloor = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "heightceiling":
                            heightceiling = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "texturefloor":
                            texturefloor = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "textureceiling":
                            textureceiling = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "lightlevel":
                            lightlevel = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "special":
                            special = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "id":
                            id = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "comment":
                            comment = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "xpanningfloor":
                            xpanningfloor = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "ypanningfloor":
                            ypanningfloor = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "xpanningceiling":
                            xpanningceiling = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "ypanningceiling":
                            ypanningceiling = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "xscalefloor":
                            xscalefloor = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "yscalefloor":
                            yscalefloor = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "xscaleceiling":
                            xscaleceiling = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "yscaleceiling":
                            yscaleceiling = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "rotationfloor":
                            rotationfloor = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "rotationceiling":
                            rotationceiling = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "ceilingplane_a":
                            ceilingplane_a = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "ceilingplane_b":
                            ceilingplane_b = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "ceilingplane_c":
                            ceilingplane_c = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "ceilingplane_d":
                            ceilingplane_d = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "floorplane_a":
                            floorplane_a = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "floorplane_b":
                            floorplane_b = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "floorplane_c":
                            floorplane_c = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "floorplane_d":
                            floorplane_d = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "lightfloor":
                            lightfloor = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "lightceiling":
                            lightceiling = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "lightfloorabsolute":
                            lightfloorabsolute = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "lightceilingabsolute":
                            lightceilingabsolute = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "alphafloor":
                            alphafloor = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "alphaceiling":
                            alphaceiling = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "renderstylefloor":
                            renderstylefloor = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "renderstyleceiling":
                            renderstyleceiling = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "gravity":
                            gravity = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "lightcolor":
                            lightcolor = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "fadecolor":
                            fadecolor = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "desaturation":
                            desaturation = float.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "silent":
                            silent = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "nofallingdamage":
                            nofallingdamage = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "dropactors":
                            dropactors = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "norespawn":
                            norespawn = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "soundsequence":
                            soundsequence = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "hidden":
                            hidden = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "waterzone":
                            waterzone = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "moreids":
                            moreids = new List<string>((chunks[1].Substring(0, chunks[1].Length - 2)).Split(' '));
                            break;
                        case "damageamount":
                            damageamount = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "damagetype":
                            damagetype = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "damageinterval":
                            damageinterval = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "leakiness":
                            leakiness = int.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "damageterraineffect":
                            damageterraineffect = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "floorterrain":
                            floorterrain = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "ceilingterrain":
                            ceilingterrain = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "portal_ceil_blocksound":
                            portal_ceil_blocksound = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "portal_ceil_disabled":
                            portal_ceil_disabled = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "portal_ceil_nopass":
                            portal_ceil_nopass = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "portal_ceil_norender":
                            portal_ceil_norender = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "portal_ceil_overlaytype":
                            portal_ceil_overlaytype = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                        case "portal_floor_blocksound":
                            portal_floor_blocksound = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "portal_floor_disabled":
                            portal_floor_disabled = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "portal_floor_nopass":
                            portal_floor_nopass = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "portal_floor_norender":
                            portal_floor_norender = bool.Parse(chunks[1].Substring(0, chunks[1].Length - 2));
                            break;
                        case "portal_floor_overlaytype":
                            portal_floor_overlaytype = chunks[1].Substring(0, chunks[1].Length - 2);
                            break;
                    }
                }
            }
        }
    }

    public class Textmap
    {
    }
}
