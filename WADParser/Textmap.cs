using System;
using System.Collections.Generic;
using System.Data;
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

        public ThingEntry(List<string> lines)
        { }

        public override string Write()
        {
            throw new NotImplementedException();
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

        public LinedefEntry(List<string> lines)
        { }

        public override string Write()
        {
            throw new NotImplementedException();
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

        public override string Write()
        {
            throw new NotImplementedException();
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
