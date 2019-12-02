using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pktReader
{
    class SubPacket
    {

        public string Data { get; set; }
        public string Title { get; set; }

        public SubPacket(string d, string t)
        {
            Data = d;
            Title = t;
        }

        public ushort determineSize(string input)
        {
            var bitOne = input.Substring(2, 2);
            var bitTwo = input.Substring(4, 2);
            var littleEnd = bitTwo + bitOne;
            var bigEnd = bitOne + bitTwo;

            return UInt16.Parse(littleEnd, System.Globalization.NumberStyles.HexNumber);
        }

        public string determineOpCode(uint size)
        {
            int unkValue;

            if (size < 12000)
            {
                unkValue = 1;
                return "?";
            }
            /* 12227 */
            if (size < 0x2f3c)
            {
                if (size < 12000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x2f3c)
                {
                    if ((uint)size - 12000 < 0x5b)
                    {
                        unkValue = 0;
                        //return &PTR_u_BP_OPCODE_BEGIN_01687bf8 + ((uint)size - 12000) * 2;
                        return "BP";
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0xcd38) < 0x2d)
            {
                if (size < 13000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x32f6)
                {
                    if ((uint)size - 13000 < 0x2d)
                    {
                        unkValue = 0;
                        //return &PTR_u_CG_OPCODE_BEGIN_01687a90 + ((uint)size - 13000) * 2;
                        return "CG";
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0xc950) < 99)
            {
                if (size < 14000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x3714)
                {
                    if ((uint)size - 14000 < 99)
                    {
                        unkValue = 0;
                        //return &PTR_u_GC_OPCODE_BEGIN_01687778 + ((uint)size - 14000) * 2;
                        return "GC";
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0xc568) < 0x70)
            {
                if (size < 15000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x3b09)
                {
                    if ((uint)size - 15000 < 0x70)
                    {
                        unkValue = 0;
                        //return &PTR_u_CL_OPCODE_BEGIN_016873f8 + ((uint)size - 15000) * 2;
                        return "CL";
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0xc180) < 0xcb)
            {
                if (size < 16000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (0x3f4b < size)
                {
                    unkValue = 4;
                    return "?";
                }
                if (0xca < (uint)size - 16000)
                {
                    unkValue = 5;
                    return "?";
                }
                unkValue = 0;
                return "LC";
                //return &PTR_u_LC_OPCODE_BEGIN_01687f10 + ((uint)size - 16000) * 2;
            }
            if ((ushort)(size + 0xbd98) < 4)
            {
                if (size < 17000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x426d)
                {
                    if ((uint)size - 17000 < 4)
                    {
                        unkValue = 0;
                        return "AC";
                        //return &PTR__AC_OPCODE_BEGIN_016873d8 + ((uint)size - 17000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0xb9b0) < 5)
            {
                if (size < 18000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x4656)
                {
                    if ((uint)size - 18000 < 5)
                    {
                        unkValue = 0;
                        return "CA";
                        //return &PTR_u_CA_OPCODE_BEGIN_016873b0 + ((uint)size - 18000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0xadf8) < 10)
            {
                if (size < 21000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x5212)
                {
                    if ((uint)size - 21000 < 9)
                    {
                        unkValue = 0;
                        return "LG";
                        //return &PTR_u_LG_OPCODE_BEGIN_01687368 + ((uint)size - 21000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0xb1e0) < 0xe)
            {
                if (size < 20000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x4e2e)
                {
                    if ((uint)size - 20000 < 0xd)
                    {
                        unkValue = 0;
                        return "GL";
                        //return &PTR_u_GL_OPCODE_BEGIN_01687300 + ((uint)size - 20000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0xa240) < 5)
            {
                if (size < 24000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x5dc5)
                {
                    if ((uint)size - 24000 < 4)
                    {
                        unkValue = 0;
                        return "DG";
                        //return &PTR_u_DG_OPCODE_BEGIN_016872e0 + ((uint)size - 24000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0x9e58) < 6)
            {
                if (size < 25000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x61ae)
                {
                    if ((uint)size - 25000 < 5)
                    {
                        unkValue = 0;
                        return "GD";
                        //return &PTR_u_GD_OPCODE_BEGIN_016872b8 + ((uint)size - 25000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0x8ad0) < 5)
            {
                if (size < 30000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x7535)
                {
                    if ((uint)size - 30000 < 4)
                    {
                        unkValue = 0;
                        return "AM";
                        //return &PTR_u_AM_OPCODE_BEGIN_01687298 + ((uint)size - 30000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0x86e8) < 9)
            {
                if (size < 31000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x7921)
                {
                    if ((uint)size - 31000 < 8)
                    {
                        unkValue = 0;
                        return "MA";
                        //return &PTR_u_MA_OPCODE_BEGIN_01687258 + ((uint)size - 31000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0x7f18) < 0xd)
            {
                if (size < 33000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x80f5)
                {
                    if ((uint)size - 33000 < 0xc)
                    {
                        unkValue = 0;
                        return "ML";
                        //return &PTR_u_ML_OPCODE_BEGIN_016871f8 + ((uint)size - 33000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0x8300) < 10)
            {
                if (size < 32000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x7d0a)
                {
                    if ((uint)size - 32000 < 9)
                    {
                        unkValue = 0;
                        return "LM";
                        //return &PTR_u_LM_OPCODE_BEGIN_016871b0 + ((uint)size - 32000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if ((ushort)(size + 0x7b30) < 5)
            {
                if (size < 34000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0x84d5)
                {
                    if ((uint)size - 34000 < 4)
                    {
                        unkValue = 0;
                        return "RM";
                        //return &PTR_u_RM_OPCODE_BEGIN_01687190 + ((uint)size - 34000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if (4 < (ushort)(size + 0x7748))
            {
                if ((ushort)(size + 0x7360) < 3)
                {
                    if (size < 36000)
                    {
                        unkValue = 3;
                        return "?";
                    }
                    if (size < 0x8ca3)
                    {
                        if ((uint)size - 36000 < 2)
                        {
                            unkValue = 0;
                            return "RS";
                            //return &PTR_u_RS_OPCODE_BEGIN_01687160 + ((uint)size - 36000) * 2;
                        }
                        unkValue = 5;
                        return "?";
                    }
                    unkValue = 4;
                    return "?";
                }
                if ((ushort)(size + 0x6f78) < 0x25)
                {
                    if (size < 37000)
                    {
                        unkValue = 3;
                        return "?";
                    }
                    if (size < 0x90ad)
                    {
                        if ((uint)size - 37000 < 0x24)
                        {
                            unkValue = 0;
                            return "SR";
                            //return &PTR_u_SR_OPCODE_BEGIN_01687040 + ((uint)size - 37000) * 2;
                        }
                        unkValue = 5;
                        return "?";
                    }
                    unkValue = 4;
                    return "?";
                }
                if ((ushort)(size + 0x6b90) < 3)
                {
                    if (size < 38000)
                    {
                        unkValue = 3;
                        return "?";
                    }
                    if (size < 0x9473)
                    {
                        if ((uint)size - 38000 < 2)
                        {
                            unkValue = 0;
                            return "TM";
                            //return &PTR_u_TM_OPCODE_BEGIN_01687030 + ((uint)size - 38000) * 2;
                        }
                        unkValue = 5;
                        return "?";
                    }
                    unkValue = 4;
                    return "?";
                }
                if ((ushort)(size + 0x67a8) < 4)
                {
                    if (size < 39000)
                    {
                        unkValue = 3;
                        return "?";
                    }
                    if (size < 0x985c)
                    {
                        if ((uint)size - 39000 < 3)
                        {
                            unkValue = 0;
                            return "MT";
                            //                            return &PTR_u_MT_OPCODE_BEGIN_01687018 + ((uint)size - 39000) * 2;
                        }
                        unkValue = 5;
                        return "?";
                    }
                    unkValue = 4;
                    return "?";
                }
                if ((ushort)(size + 0xaa10) < 0x2a)
                {
                    if (size < 22000)
                    {
                        unkValue = 3;
                        return "?";
                    }
                    if (size < 0x561a)
                    {
                        if ((uint)size - 22000 < 0x29)
                        {
                            unkValue = 0;
                            return "TL";
                            //return &PTR_u_TL_OPCODE_BEGIN_01686ed0 + ((uint)size - 22000) * 2;
                        }
                        unkValue = 5;
                        return "?";
                    }
                    unkValue = 4;
                    return "?";
                }
                if ((ushort)(size + 0xa628) < 0x2e)
                {
                    if (size < 23000)
                    {
                        unkValue = 3;
                        return "?";
                    }
                    if (size < 0x5a06)
                    {
                        if ((uint)size - 23000 < 0x2d)
                        {
                            unkValue = 0;
                            return "LT";
                            //                            return &PTR_u_LT_OPCODE_BEGIN_01686d68 + ((uint)size - 23000) * 2;
                        }
                        unkValue = 5;
                        return "?";
                    }
                    unkValue = 4;
                    return "?";
                }
                if ((ushort)(size + 0x63c0) < 5)
                {
                    if (size < 40000)
                    {
                        unkValue = 3;
                        return "?";
                    }
                    if (size < 0x9c45)
                    {
                        if ((uint)size - 40000 < 4)
                        {
                            unkValue = 0;
                            return "GM";
                            //return &PTR_u_GM_OPCODE_BEGIN_01686d48 + ((uint)size - 40000) * 2;
                        }
                        unkValue = 5;
                        return "?";
                    }
                    unkValue = 4;
                    return "?";
                }
                if (7 < (ushort)(size + 0x5fd8))
                {
                    if ((ushort)(size + 0x5bf0) < 6)
                    {
                        if (size < 42000)
                        {
                            unkValue = 3;
                            return "?";
                        }
                        if (size < 0xa416)
                        {
                            if ((uint)size - 42000 < 5)
                            {
                                unkValue = 0;
                                return "PL";
                                //return &PTR_u_PL_OPCODE_BEGIN_01686ce8 + ((uint)size - 42000) * 2;
                            }
                            unkValue = 5;
                            return "?";
                        }
                        unkValue = 4;
                        return "?";
                    }
                    if ((42999 < size) && (size < 0xa807))
                    {
                        if (size < 43000)
                        {
                            unkValue = 3;
                            return "?";
                        }
                        if (size < 0xa807)
                        {
                            if ((uint)size - 43000 < 0xe)
                            {
                                unkValue = 0;
                                return "PT";
                                //return &PTR_u_PT_OPCODE_BEGIN_01686c78 + ((uint)size - 43000) * 2;
                            }
                            unkValue = 5;
                            return "?";
                        }
                        unkValue = 4;
                        return "?";
                    }
                    if ((ushort)(size + 0x5420) < 3)
                    {
                        if (size < 44000)
                        {
                            unkValue = 3;
                            return "?";
                        }
                        if (size < 0xabe3)
                        {
                            if ((uint)size - 44000 < 2)
                            {
                                unkValue = 0;
                                return "EM";
                                //return &PTR_u_EM_OPCODE_BEGIN_01686c64 + ((uint)size - 44000) * 2;
                            }
                            unkValue = 5;
                            return "?";
                        }
                        unkValue = 4;
                        return "?";
                    }
                    if (2 < (ushort)(size + 0x5038))
                    {
                        if ((ushort)(size + 0x4c50) < 3)
                        {
                            if (size < 46000)
                            {
                                unkValue = 3;
                                return "?";
                            }
                            if (size < 0xb3b3)
                            {
                                if ((uint)size - 46000 < 2)
                                {
                                    unkValue = 0;
                                    return "EG";
                                    //return &PTR_u_EG_OPCODE_BEGIN_01686c44 + ((uint)size - 46000) * 2;
                                }
                                unkValue = 5;
                                return "?";
                            }
                            unkValue = 4;
                            return "?";
                        }
                        if (((5 < (ushort)(size + 0x4868)) && (6 < (ushort)(size + 0x15a0))) &&
                           (5 < (ushort)(size + 0x11b8)))
                        {
                            unkValue = 2;
                            return "?";
                        }
                        if (size < 47000)
                        {
                            unkValue = 3;
                            return "?";
                        }
                        if (size < 0xb79e)
                        {
                            if ((uint)size - 47000 < 5)
                            {
                                unkValue = 0;
                                return "GE";
                                //return &PTR_u_GE_OPCODE_BEGIN_01686c1c + ((uint)size - 47000) * 2;
                            }
                            unkValue = 5;
                            return "?";
                        }
                        unkValue = 4;
                        return "?";
                    }
                    if (size < 45000)
                    {
                        unkValue = 3;
                        return "?";
                    }
                    if (size < 0xafcb)
                    {
                        if ((uint)size - 45000 < 2)
                        {
                            unkValue = 0;
                            return "ME";
                            //return &PTR_u_ME_OPCODE_BEGIN_01686c54 + ((uint)size - 45000) * 2;
                        }
                        unkValue = 5;
                        return "?";
                    }
                    unkValue = 4;
                    return "?";
                }
                if (size < 41000)
                {
                    unkValue = 3;
                    return "?";
                }
                if (size < 0xa030)
                {
                    if ((uint)size - 41000 < 7)
                    {
                        unkValue = 0;
                        return "MG";
                        //return &PTR_u_MG_OPCODE_BEGIN_01686d10 + ((uint)size - 41000) * 2;
                    }
                    unkValue = 5;
                    return "?";
                }
                unkValue = 4;
                return "?";
            }
            if (size < 35000)
            {
                unkValue = 3;
                return "?";
            }
            if (size < 0x88bd)
            {
                if ((uint)size - 35000 < 4)
                {
                    unkValue = 0;
                    return "MR";
                    //return &PTR_u_MR_OPCODE_BEGIN_01687170 + ((uint)size - 35000) * 2;
                }
                unkValue = 5;
                return "?";
            }
            unkValue = 4;
            return "?";
        }

    }
}

