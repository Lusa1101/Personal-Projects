; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [343 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [680 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 253
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 287
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39485524, ; 6: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 7: System.Threading.Thread => 0x28aa24d => 145
	i32 57725457, ; 8: it\Microsoft.Data.SqlClient.resources => 0x370d211 => 298
	i32 57727992, ; 9: ja\Microsoft.Data.SqlClient.resources => 0x370dbf8 => 299
	i32 66541672, ; 10: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 11: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 338
	i32 68219467, ; 12: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 13: Microsoft.Maui.Graphics.dll => 0x44bb714 => 203
	i32 82292897, ; 14: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 101534019, ; 15: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 271
	i32 117431740, ; 16: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 17: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 271
	i32 122350210, ; 18: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 19: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 291
	i32 139659294, ; 20: ja/Microsoft.Data.SqlClient.resources.dll => 0x853081e => 299
	i32 142721839, ; 21: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 22: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 23: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 24: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 227
	i32 166535111, ; 25: ru/Microsoft.Data.SqlClient.resources.dll => 0x9ed1fc7 => 302
	i32 176265551, ; 26: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 27: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 273
	i32 184328833, ; 28: System.ValueTuple.dll => 0xafca281 => 151
	i32 195452805, ; 29: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 335
	i32 199333315, ; 30: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 336
	i32 205061960, ; 31: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 32: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 225
	i32 220171995, ; 33: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 34: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 247
	i32 230752869, ; 35: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 36: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 37: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 38: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 39: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 230
	i32 264223668, ; 40: zh-Hans\Microsoft.Data.SqlClient.resources => 0xfbfbbb4 => 303
	i32 276479776, ; 41: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 42: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 249
	i32 280482487, ; 43: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 246
	i32 280992041, ; 44: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 307
	i32 291076382, ; 45: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 298918909, ; 46: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 47: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 335
	i32 318968648, ; 48: Xamarin.AndroidX.Activity.dll => 0x13031348 => 216
	i32 321597661, ; 49: System.Numerics => 0x132b30dd => 83
	i32 330147069, ; 50: Microsoft.SqlServer.Server => 0x13ada4fd => 204
	i32 336156722, ; 51: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 320
	i32 342366114, ; 52: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 248
	i32 356389973, ; 53: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 319
	i32 360082299, ; 54: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 55: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 56: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 57: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 58: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 59: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 60: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 61: _Microsoft.Android.Resource.Designer => 0x17969339 => 339
	i32 403441872, ; 62: WindowsBase => 0x180c08d0 => 165
	i32 435591531, ; 63: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 331
	i32 441335492, ; 64: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 231
	i32 442565967, ; 65: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 66: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 244
	i32 451504562, ; 67: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 68: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 69: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 70: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 71: System.dll => 0x1bff388e => 164
	i32 476646585, ; 72: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 246
	i32 485463106, ; 73: Microsoft.IdentityModel.Abstractions => 0x1cef9442 => 192
	i32 486930444, ; 74: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 259
	i32 498788369, ; 75: System.ObjectModel => 0x1dbae811 => 84
	i32 500358224, ; 76: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 318
	i32 503918385, ; 77: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 312
	i32 513247710, ; 78: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 189
	i32 526420162, ; 79: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 80: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 291
	i32 530272170, ; 81: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 539058512, ; 82: Microsoft.Extensions.Logging => 0x20216150 => 185
	i32 540030774, ; 83: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 84: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 85: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 548916678, ; 86: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 179
	i32 549171840, ; 87: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 88: Jsr305Binding => 0x213954e7 => 284
	i32 569601784, ; 89: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 282
	i32 577335427, ; 90: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 592146354, ; 91: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 326
	i32 597488923, ; 92: CommunityToolkit.Maui => 0x239cf51b => 175
	i32 601371474, ; 93: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 94: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 95: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 96: Xamarin.AndroidX.CustomView => 0x2568904f => 236
	i32 627931235, ; 97: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 324
	i32 639843206, ; 98: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 242
	i32 643868501, ; 99: System.Net => 0x2660a755 => 81
	i32 662205335, ; 100: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 101: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 278
	i32 666292255, ; 102: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 223
	i32 672442732, ; 103: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 104: System.Net.Security => 0x28bdabca => 73
	i32 688181140, ; 105: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 306
	i32 690569205, ; 106: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 107: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 293
	i32 693804605, ; 108: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 109: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 110: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 288
	i32 700358131, ; 111: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 706645707, ; 112: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 321
	i32 709557578, ; 113: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 309
	i32 720511267, ; 114: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 292
	i32 722857257, ; 115: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 723796036, ; 116: System.ClientModel.dll => 0x2b244044 => 205
	i32 735137430, ; 117: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 118: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 119: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 213
	i32 759454413, ; 120: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 121: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 122: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 123: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 330
	i32 789151979, ; 124: Microsoft.Extensions.Options => 0x2f0980eb => 188
	i32 790371945, ; 125: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 237
	i32 804715423, ; 126: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 127: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 251
	i32 823281589, ; 128: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 129: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 130: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 131: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 132: Xamarin.AndroidX.Print => 0x3246f6cd => 264
	i32 873119928, ; 133: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 134: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 135: System.Net.Http.Json => 0x3463c971 => 63
	i32 904024072, ; 136: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 137: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 926902833, ; 138: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 333
	i32 928116545, ; 139: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 287
	i32 952186615, ; 140: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 956575887, ; 141: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 292
	i32 966729478, ; 142: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 285
	i32 967690846, ; 143: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 248
	i32 975236339, ; 144: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 145: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 146: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 147: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 148: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 149: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 150: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 151: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 268
	i32 1019214401, ; 152: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 153: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 184
	i32 1029334545, ; 154: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 308
	i32 1031528504, ; 155: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 286
	i32 1035644815, ; 156: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 221
	i32 1036536393, ; 157: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1044663988, ; 158: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1048439329, ; 159: de/Microsoft.Data.SqlClient.resources.dll => 0x3e7dea21 => 295
	i32 1052210849, ; 160: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 255
	i32 1062017875, ; 161: Microsoft.Identity.Client.Extensions.Msal => 0x3f4d1b53 => 191
	i32 1067306892, ; 162: GoogleGson => 0x3f9dcf8c => 178
	i32 1082857460, ; 163: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 164: Xamarin.Kotlin.StdLib => 0x409e66d8 => 289
	i32 1089913930, ; 165: System.Diagnostics.EventLog.dll => 0x40f6c44a => 207
	i32 1098259244, ; 166: System => 0x41761b2c => 164
	i32 1118262833, ; 167: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 321
	i32 1121599056, ; 168: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 254
	i32 1127624469, ; 169: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 187
	i32 1138436374, ; 170: Microsoft.Data.SqlClient.dll => 0x43db2916 => 180
	i32 1149092582, ; 171: Xamarin.AndroidX.Window => 0x447dc2e6 => 281
	i32 1168523401, ; 172: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 327
	i32 1170634674, ; 173: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 174: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 277
	i32 1178241025, ; 175: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 262
	i32 1203215381, ; 176: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 325
	i32 1204270330, ; 177: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 223
	i32 1208641965, ; 178: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1214827643, ; 179: CommunityToolkit.Mvvm => 0x4868cc7b => 177
	i32 1219128291, ; 180: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1234928153, ; 181: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 323
	i32 1243150071, ; 182: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 282
	i32 1253011324, ; 183: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 184: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 307
	i32 1264511973, ; 185: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 272
	i32 1267360935, ; 186: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 276
	i32 1273260888, ; 187: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 228
	i32 1275534314, ; 188: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 293
	i32 1278448581, ; 189: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 220
	i32 1293217323, ; 190: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 239
	i32 1309188875, ; 191: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 192: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 281
	i32 1324164729, ; 193: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 194: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1364015309, ; 195: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 196: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 337
	i32 1376866003, ; 197: Xamarin.AndroidX.SavedState => 0x52114ed3 => 268
	i32 1379779777, ; 198: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 199: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 200: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 232
	i32 1408764838, ; 201: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 202: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 203: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 204: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 305
	i32 1434145427, ; 205: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 206: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 285
	i32 1439761251, ; 207: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 208: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 209: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 210: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 211: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1460893475, ; 212: System.IdentityModel.Tokens.Jwt => 0x57137723 => 208
	i32 1461004990, ; 213: es\Microsoft.Maui.Controls.resources => 0x57152abe => 311
	i32 1461234159, ; 214: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 215: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 216: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 217: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 222
	i32 1470490898, ; 218: Microsoft.Extensions.Primitives => 0x57a5e912 => 189
	i32 1479771757, ; 219: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 220: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 221: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 222: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 269
	i32 1493001747, ; 223: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 315
	i32 1498168481, ; 224: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 193
	i32 1514721132, ; 225: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 310
	i32 1536373174, ; 226: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 227: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 228: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 229: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1551623176, ; 230: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 330
	i32 1565310744, ; 231: System.Runtime.Caching => 0x5d4cbf18 => 210
	i32 1565862583, ; 232: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 233: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 234: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 235: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582305585, ; 236: Azure.Identity => 0x5e501131 => 174
	i32 1582372066, ; 237: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 238
	i32 1592978981, ; 238: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1596263029, ; 239: zh-Hant\Microsoft.Data.SqlClient.resources => 0x5f250a75 => 304
	i32 1597949149, ; 240: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 286
	i32 1601112923, ; 241: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 242: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 243: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 244: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 258
	i32 1622358360, ; 245: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 246: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 280
	i32 1628113371, ; 247: Microsoft.IdentityModel.Protocols.OpenIdConnect => 0x610b09db => 196
	i32 1634654947, ; 248: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 176
	i32 1635184631, ; 249: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 242
	i32 1636350590, ; 250: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 235
	i32 1639515021, ; 251: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 252: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 253: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 254: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 255: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 274
	i32 1658251792, ; 256: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 283
	i32 1670060433, ; 257: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 230
	i32 1675553242, ; 258: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 259: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 260: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 261: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 262: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 263: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 264: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 290
	i32 1701541528, ; 265: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 266: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 251
	i32 1726116996, ; 267: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 268: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 269: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 226
	i32 1736233607, ; 270: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 328
	i32 1743415430, ; 271: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 306
	i32 1744735666, ; 272: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 273: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 274: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 275: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 276: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 277: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 278: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 273
	i32 1770582343, ; 279: Microsoft.Extensions.Logging.dll => 0x6988f147 => 185
	i32 1776026572, ; 280: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 281: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 282: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 283: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 322
	i32 1788241197, ; 284: Xamarin.AndroidX.Fragment => 0x6a96652d => 244
	i32 1793755602, ; 285: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 314
	i32 1794500907, ; 286: Microsoft.Identity.Client.dll => 0x6af5e92b => 190
	i32 1796167890, ; 287: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 179
	i32 1808609942, ; 288: Xamarin.AndroidX.Loader => 0x6bcd3296 => 258
	i32 1813058853, ; 289: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 289
	i32 1813201214, ; 290: Xamarin.Google.Android.Material => 0x6c13413e => 283
	i32 1818569960, ; 291: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 263
	i32 1818787751, ; 292: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 293: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 294: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 295: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 186
	i32 1842015223, ; 296: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 334
	i32 1847515442, ; 297: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 213
	i32 1853025655, ; 298: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 331
	i32 1858542181, ; 299: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 300: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1871986876, ; 301: Microsoft.IdentityModel.Protocols.OpenIdConnect.dll => 0x6f9440bc => 196
	i32 1875935024, ; 302: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 313
	i32 1879696579, ; 303: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 304: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 224
	i32 1888955245, ; 305: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 306: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1898237753, ; 307: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 308: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 309: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 310: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 311: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 312: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 270
	i32 1968388702, ; 313: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 181
	i32 1983156543, ; 314: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 290
	i32 1985761444, ; 315: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 215
	i32 1986222447, ; 316: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 197
	i32 2003115576, ; 317: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 310
	i32 2011961780, ; 318: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 319: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 255
	i32 2025202353, ; 320: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 305
	i32 2031763787, ; 321: Xamarin.Android.Glide => 0x791a414b => 212
	i32 2040764568, ; 322: Microsoft.Identity.Client.Extensions.Msal.dll => 0x79a39898 => 191
	i32 2045470958, ; 323: System.Private.Xml => 0x79eb68ee => 88
	i32 2055257422, ; 324: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 250
	i32 2060060697, ; 325: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 326: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 309
	i32 2070888862, ; 327: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 328: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 329: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2127167465, ; 330: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 331: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 332: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 333: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 334: Microsoft.Maui => 0x80bd55ad => 201
	i32 2169148018, ; 335: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 317
	i32 2181898931, ; 336: Microsoft.Extensions.Options.dll => 0x820d22b3 => 188
	i32 2192057212, ; 337: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 186
	i32 2193016926, ; 338: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 339: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 294
	i32 2201231467, ; 340: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 341: it\Microsoft.Maui.Controls.resources => 0x839595db => 319
	i32 2217644978, ; 342: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 277
	i32 2222056684, ; 343: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2228745826, ; 344: pt-BR\Microsoft.Data.SqlClient.resources => 0x84d7f662 => 301
	i32 2244775296, ; 345: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 259
	i32 2252106437, ; 346: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2253551641, ; 347: Microsoft.IdentityModel.Protocols => 0x86527819 => 195
	i32 2256313426, ; 348: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 349: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 350: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 182
	i32 2267999099, ; 351: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 214
	i32 2270573516, ; 352: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 313
	i32 2279755925, ; 353: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 266
	i32 2293034957, ; 354: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 355: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 356: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 357: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 323
	i32 2305521784, ; 358: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2309278602, ; 359: ko\Microsoft.Data.SqlClient.resources => 0x89a4cb8a => 300
	i32 2315684594, ; 360: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 218
	i32 2320631194, ; 361: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 362: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 363: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 364: System.Net.Primitives => 0x8c40e0db => 70
	i32 2368005991, ; 365: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2369706906, ; 366: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 194
	i32 2371007202, ; 367: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 181
	i32 2378619854, ; 368: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 369: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 370: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 318
	i32 2401565422, ; 371: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 372: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 241
	i32 2421380589, ; 373: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 374: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 228
	i32 2427813419, ; 375: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 315
	i32 2435356389, ; 376: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 377: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 378: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 379: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 380: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 381: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 231
	i32 2471841756, ; 382: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 383: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 384: Microsoft.Maui.Controls => 0x93dba8a1 => 199
	i32 2483903535, ; 385: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 386: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 387: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 388: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 389: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 253
	i32 2509217888, ; 390: System.Diagnostics.EventLog => 0x958fa060 => 207
	i32 2522472828, ; 391: Xamarin.Android.Glide.dll => 0x9659e17c => 212
	i32 2538310050, ; 392: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 393: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 316
	i32 2562349572, ; 394: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 395: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2581783588, ; 396: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 254
	i32 2581819634, ; 397: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 276
	i32 2585220780, ; 398: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 399: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 400: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2593496499, ; 401: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 325
	i32 2605712449, ; 402: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 294
	i32 2615233544, ; 403: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 245
	i32 2616218305, ; 404: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 187
	i32 2617129537, ; 405: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 406: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 407: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 235
	i32 2624592528, ; 408: BusinessManager => 0x9c701a90 => 0
	i32 2624644809, ; 409: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 240
	i32 2626831493, ; 410: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 320
	i32 2627185994, ; 411: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2628210652, ; 412: System.Memory.Data => 0x9ca74fdc => 209
	i32 2629843544, ; 413: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 414: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 249
	i32 2640290731, ; 415: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 194
	i32 2640706905, ; 416: Azure.Core => 0x9d65fd59 => 173
	i32 2660759594, ; 417: System.Security.Cryptography.ProtectedData.dll => 0x9e97f82a => 211
	i32 2663391936, ; 418: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 214
	i32 2663698177, ; 419: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 420: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 421: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 422: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2677098746, ; 423: Azure.Identity.dll => 0x9f9148fa => 174
	i32 2686887180, ; 424: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 425: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 426: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 274
	i32 2715334215, ; 427: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 428: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 429: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 430: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 431: Xamarin.AndroidX.Activity => 0xa2e0939b => 216
	i32 2735172069, ; 432: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 433: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 222
	i32 2740051746, ; 434: Microsoft.Identity.Client => 0xa351df22 => 190
	i32 2740948882, ; 435: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 436: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 437: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 326
	i32 2755098380, ; 438: Microsoft.SqlServer.Server.dll => 0xa437770c => 204
	i32 2758225723, ; 439: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 200
	i32 2764765095, ; 440: Microsoft.Maui.dll => 0xa4caf7a7 => 201
	i32 2765824710, ; 441: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 442: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 288
	i32 2778768386, ; 443: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 279
	i32 2779977773, ; 444: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 267
	i32 2785988530, ; 445: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 332
	i32 2788224221, ; 446: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 245
	i32 2801831435, ; 447: Microsoft.Maui.Graphics => 0xa7008e0b => 203
	i32 2803228030, ; 448: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2804509662, ; 449: es/Microsoft.Data.SqlClient.resources.dll => 0xa7296bde => 296
	i32 2806116107, ; 450: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 311
	i32 2810250172, ; 451: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 232
	i32 2819470561, ; 452: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 453: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 454: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 267
	i32 2824502124, ; 455: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2831556043, ; 456: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 324
	i32 2838993487, ; 457: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 256
	i32 2841937114, ; 458: it/Microsoft.Data.SqlClient.resources.dll => 0xa96484da => 298
	i32 2849599387, ; 459: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 460: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 279
	i32 2855708567, ; 461: Xamarin.AndroidX.Transition => 0xaa36a797 => 275
	i32 2861098320, ; 462: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 463: Microsoft.Maui.Essentials => 0xaa8a4878 => 202
	i32 2867946736, ; 464: System.Security.Cryptography.ProtectedData => 0xaaf164f0 => 211
	i32 2868488919, ; 465: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 176
	i32 2870099610, ; 466: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 217
	i32 2875164099, ; 467: Jsr305Binding.dll => 0xab5f85c3 => 284
	i32 2875220617, ; 468: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 469: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 243
	i32 2887636118, ; 470: System.Net.dll => 0xac1dd496 => 81
	i32 2899753641, ; 471: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 472: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 473: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 474: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 475: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 476: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 280
	i32 2919462931, ; 477: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 478: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 219
	i32 2936416060, ; 479: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 480: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 481: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2944313911, ; 482: System.Configuration.ConfigurationManager.dll => 0xaf7eaa37 => 206
	i32 2959614098, ; 483: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 484: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 485: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 486: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 239
	i32 2987532451, ; 487: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 270
	i32 2996846495, ; 488: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 252
	i32 3012788804, ; 489: System.Configuration.ConfigurationManager => 0xb3938244 => 206
	i32 3016983068, ; 490: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 272
	i32 3023353419, ; 491: WindowsBase.dll => 0xb434b64b => 165
	i32 3023511517, ; 492: ru\Microsoft.Data.SqlClient.resources => 0xb4371fdd => 302
	i32 3024354802, ; 493: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 247
	i32 3033605958, ; 494: System.Memory.Data.dll => 0xb4d12746 => 209
	i32 3038032645, ; 495: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 339
	i32 3056245963, ; 496: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 269
	i32 3057625584, ; 497: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 260
	i32 3059408633, ; 498: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 499: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 500: System.Threading.Tasks => 0xb755818f => 144
	i32 3077302341, ; 501: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 317
	i32 3084678329, ; 502: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 197
	i32 3090735792, ; 503: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 504: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 505: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 506: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 507: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 508: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 509: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 510: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 511: GoogleGson.dll => 0xbba64c02 => 178
	i32 3158628304, ; 512: zh-Hant/Microsoft.Data.SqlClient.resources.dll => 0xbc44d7d0 => 304
	i32 3159123045, ; 513: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 514: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 515: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 261
	i32 3192346100, ; 516: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 517: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 518: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 519: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 520: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 238
	i32 3220365878, ; 521: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 522: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 523: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 524: Xamarin.AndroidX.CardView => 0xc235e84d => 226
	i32 3265493905, ; 525: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 526: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3268887220, ; 527: fr/Microsoft.Data.SqlClient.resources.dll => 0xc2d742b4 => 297
	i32 3276600297, ; 528: pt-BR/Microsoft.Data.SqlClient.resources.dll => 0xc34cf3e9 => 301
	i32 3277815716, ; 529: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 530: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 531: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 532: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 533: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 534: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 535: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 312
	i32 3312457198, ; 536: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 193
	i32 3316684772, ; 537: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 538: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 236
	i32 3317144872, ; 539: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 540: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 224
	i32 3343947874, ; 541: fr\Microsoft.Data.SqlClient.resources => 0xc7509862 => 297
	i32 3345895724, ; 542: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 265
	i32 3346324047, ; 543: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 262
	i32 3357674450, ; 544: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 329
	i32 3358260929, ; 545: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 546: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 217
	i32 3362522851, ; 547: Xamarin.AndroidX.Core => 0xc86c06e3 => 233
	i32 3366347497, ; 548: Java.Interop => 0xc8a662e9 => 168
	i32 3374879918, ; 549: Microsoft.IdentityModel.Protocols.dll => 0xc92894ae => 195
	i32 3374999561, ; 550: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 266
	i32 3381016424, ; 551: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 308
	i32 3395150330, ; 552: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 553: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 554: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 237
	i32 3428513518, ; 555: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 183
	i32 3429136800, ; 556: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 557: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 558: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 240
	i32 3445260447, ; 559: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 560: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 198
	i32 3463511458, ; 561: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 316
	i32 3471940407, ; 562: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 563: Mono.Android => 0xcf3163e6 => 171
	i32 3479583265, ; 564: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 329
	i32 3484440000, ; 565: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 328
	i32 3485117614, ; 566: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 567: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 568: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 229
	i32 3509114376, ; 569: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 570: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 571: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 572: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3545306353, ; 573: Microsoft.Data.SqlClient => 0xd35114f1 => 180
	i32 3555084973, ; 574: de\Microsoft.Data.SqlClient.resources => 0xd3e64aad => 295
	i32 3558648585, ; 575: System.ClientModel => 0xd41cab09 => 205
	i32 3560100363, ; 576: System.Threading.Timer => 0xd432d20b => 147
	i32 3561949811, ; 577: Azure.Core.dll => 0xd44f0a73 => 173
	i32 3570554715, ; 578: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3570608287, ; 579: System.Runtime.Caching.dll => 0xd4d3289f => 210
	i32 3580758918, ; 580: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 336
	i32 3597029428, ; 581: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 215
	i32 3598340787, ; 582: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 583: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 584: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 585: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 264
	i32 3633644679, ; 586: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 219
	i32 3638274909, ; 587: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 588: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 250
	i32 3643446276, ; 589: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 333
	i32 3643854240, ; 590: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 261
	i32 3645089577, ; 591: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 592: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 182
	i32 3660523487, ; 593: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 594: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 595: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 225
	i32 3684561358, ; 596: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 229
	i32 3697841164, ; 597: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 338
	i32 3700591436, ; 598: Microsoft.IdentityModel.Abstractions.dll => 0xdc928b4c => 192
	i32 3700866549, ; 599: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 600: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 234
	i32 3716563718, ; 601: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 602: Xamarin.AndroidX.Annotation => 0xdda814c6 => 218
	i32 3724971120, ; 603: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 260
	i32 3732100267, ; 604: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 605: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 606: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 607: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3786282454, ; 608: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 227
	i32 3792276235, ; 609: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 610: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 198
	i32 3802395368, ; 611: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3803019198, ; 612: zh-Hans/Microsoft.Data.SqlClient.resources.dll => 0xe2ad77be => 303
	i32 3817368567, ; 613: CommunityToolkit.Maui.dll => 0xe3886bf7 => 175
	i32 3819260425, ; 614: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 615: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 616: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 617: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 184
	i32 3844307129, ; 618: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3848348906, ; 619: es\Microsoft.Data.SqlClient.resources => 0xe56124ea => 296
	i32 3849253459, ; 620: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 621: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 622: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 623: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 624: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 625: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 275
	i32 3888767677, ; 626: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 265
	i32 3889960447, ; 627: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 337
	i32 3896106733, ; 628: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 629: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 233
	i32 3901907137, ; 630: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 631: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 632: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 278
	i32 3928044579, ; 633: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 634: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 635: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 263
	i32 3945713374, ; 636: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 637: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 638: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 221
	i32 3959773229, ; 639: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 252
	i32 3980434154, ; 640: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 332
	i32 3987592930, ; 641: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 314
	i32 4003436829, ; 642: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 643: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 220
	i32 4025784931, ; 644: System.Memory => 0xeff49a63 => 62
	i32 4046471985, ; 645: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 200
	i32 4054681211, ; 646: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 647: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 648: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4094352644, ; 649: Microsoft.Maui.Essentials.dll => 0xf40add04 => 202
	i32 4099507663, ; 650: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 651: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 652: Xamarin.AndroidX.Emoji2 => 0xf479582c => 241
	i32 4102112229, ; 653: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 327
	i32 4104716166, ; 654: BusinessManager.dll => 0xf4a8ff86 => 0
	i32 4125707920, ; 655: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 322
	i32 4126470640, ; 656: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 183
	i32 4127667938, ; 657: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 658: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 659: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 660: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 334
	i32 4151237749, ; 661: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 662: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 663: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 664: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 665: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 666: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 257
	i32 4185676441, ; 667: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 668: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 669: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4256097574, ; 670: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 234
	i32 4257443520, ; 671: ko/Microsoft.Data.SqlClient.resources.dll => 0xfdc36ec0 => 300
	i32 4258378803, ; 672: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 256
	i32 4260525087, ; 673: System.Buffers => 0xfdf2741f => 7
	i32 4263231520, ; 674: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 208
	i32 4271975918, ; 675: Microsoft.Maui.Controls.dll => 0xfea12dee => 199
	i32 4274623895, ; 676: CommunityToolkit.Mvvm.dll => 0xfec99597 => 177
	i32 4274976490, ; 677: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 678: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 257
	i32 4294763496 ; 679: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 243
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [680 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 253, ; 3
	i32 287, ; 4
	i32 48, ; 5
	i32 80, ; 6
	i32 145, ; 7
	i32 298, ; 8
	i32 299, ; 9
	i32 30, ; 10
	i32 338, ; 11
	i32 124, ; 12
	i32 203, ; 13
	i32 102, ; 14
	i32 271, ; 15
	i32 107, ; 16
	i32 271, ; 17
	i32 139, ; 18
	i32 291, ; 19
	i32 299, ; 20
	i32 77, ; 21
	i32 124, ; 22
	i32 13, ; 23
	i32 227, ; 24
	i32 302, ; 25
	i32 132, ; 26
	i32 273, ; 27
	i32 151, ; 28
	i32 335, ; 29
	i32 336, ; 30
	i32 18, ; 31
	i32 225, ; 32
	i32 26, ; 33
	i32 247, ; 34
	i32 1, ; 35
	i32 59, ; 36
	i32 42, ; 37
	i32 91, ; 38
	i32 230, ; 39
	i32 303, ; 40
	i32 147, ; 41
	i32 249, ; 42
	i32 246, ; 43
	i32 307, ; 44
	i32 54, ; 45
	i32 69, ; 46
	i32 335, ; 47
	i32 216, ; 48
	i32 83, ; 49
	i32 204, ; 50
	i32 320, ; 51
	i32 248, ; 52
	i32 319, ; 53
	i32 131, ; 54
	i32 55, ; 55
	i32 149, ; 56
	i32 74, ; 57
	i32 145, ; 58
	i32 62, ; 59
	i32 146, ; 60
	i32 339, ; 61
	i32 165, ; 62
	i32 331, ; 63
	i32 231, ; 64
	i32 12, ; 65
	i32 244, ; 66
	i32 125, ; 67
	i32 152, ; 68
	i32 113, ; 69
	i32 166, ; 70
	i32 164, ; 71
	i32 246, ; 72
	i32 192, ; 73
	i32 259, ; 74
	i32 84, ; 75
	i32 318, ; 76
	i32 312, ; 77
	i32 189, ; 78
	i32 150, ; 79
	i32 291, ; 80
	i32 60, ; 81
	i32 185, ; 82
	i32 51, ; 83
	i32 103, ; 84
	i32 114, ; 85
	i32 179, ; 86
	i32 40, ; 87
	i32 284, ; 88
	i32 282, ; 89
	i32 120, ; 90
	i32 326, ; 91
	i32 175, ; 92
	i32 52, ; 93
	i32 44, ; 94
	i32 119, ; 95
	i32 236, ; 96
	i32 324, ; 97
	i32 242, ; 98
	i32 81, ; 99
	i32 136, ; 100
	i32 278, ; 101
	i32 223, ; 102
	i32 8, ; 103
	i32 73, ; 104
	i32 306, ; 105
	i32 155, ; 106
	i32 293, ; 107
	i32 154, ; 108
	i32 92, ; 109
	i32 288, ; 110
	i32 45, ; 111
	i32 321, ; 112
	i32 309, ; 113
	i32 292, ; 114
	i32 109, ; 115
	i32 205, ; 116
	i32 129, ; 117
	i32 25, ; 118
	i32 213, ; 119
	i32 72, ; 120
	i32 55, ; 121
	i32 46, ; 122
	i32 330, ; 123
	i32 188, ; 124
	i32 237, ; 125
	i32 22, ; 126
	i32 251, ; 127
	i32 86, ; 128
	i32 43, ; 129
	i32 160, ; 130
	i32 71, ; 131
	i32 264, ; 132
	i32 3, ; 133
	i32 42, ; 134
	i32 63, ; 135
	i32 16, ; 136
	i32 53, ; 137
	i32 333, ; 138
	i32 287, ; 139
	i32 105, ; 140
	i32 292, ; 141
	i32 285, ; 142
	i32 248, ; 143
	i32 34, ; 144
	i32 158, ; 145
	i32 85, ; 146
	i32 32, ; 147
	i32 12, ; 148
	i32 51, ; 149
	i32 56, ; 150
	i32 268, ; 151
	i32 36, ; 152
	i32 184, ; 153
	i32 308, ; 154
	i32 286, ; 155
	i32 221, ; 156
	i32 35, ; 157
	i32 58, ; 158
	i32 295, ; 159
	i32 255, ; 160
	i32 191, ; 161
	i32 178, ; 162
	i32 17, ; 163
	i32 289, ; 164
	i32 207, ; 165
	i32 164, ; 166
	i32 321, ; 167
	i32 254, ; 168
	i32 187, ; 169
	i32 180, ; 170
	i32 281, ; 171
	i32 327, ; 172
	i32 153, ; 173
	i32 277, ; 174
	i32 262, ; 175
	i32 325, ; 176
	i32 223, ; 177
	i32 29, ; 178
	i32 177, ; 179
	i32 52, ; 180
	i32 323, ; 181
	i32 282, ; 182
	i32 5, ; 183
	i32 307, ; 184
	i32 272, ; 185
	i32 276, ; 186
	i32 228, ; 187
	i32 293, ; 188
	i32 220, ; 189
	i32 239, ; 190
	i32 85, ; 191
	i32 281, ; 192
	i32 61, ; 193
	i32 112, ; 194
	i32 57, ; 195
	i32 337, ; 196
	i32 268, ; 197
	i32 99, ; 198
	i32 19, ; 199
	i32 232, ; 200
	i32 111, ; 201
	i32 101, ; 202
	i32 102, ; 203
	i32 305, ; 204
	i32 104, ; 205
	i32 285, ; 206
	i32 71, ; 207
	i32 38, ; 208
	i32 32, ; 209
	i32 103, ; 210
	i32 73, ; 211
	i32 208, ; 212
	i32 311, ; 213
	i32 9, ; 214
	i32 123, ; 215
	i32 46, ; 216
	i32 222, ; 217
	i32 189, ; 218
	i32 9, ; 219
	i32 43, ; 220
	i32 4, ; 221
	i32 269, ; 222
	i32 315, ; 223
	i32 193, ; 224
	i32 310, ; 225
	i32 31, ; 226
	i32 138, ; 227
	i32 92, ; 228
	i32 93, ; 229
	i32 330, ; 230
	i32 210, ; 231
	i32 49, ; 232
	i32 141, ; 233
	i32 112, ; 234
	i32 140, ; 235
	i32 174, ; 236
	i32 238, ; 237
	i32 115, ; 238
	i32 304, ; 239
	i32 286, ; 240
	i32 157, ; 241
	i32 76, ; 242
	i32 79, ; 243
	i32 258, ; 244
	i32 37, ; 245
	i32 280, ; 246
	i32 196, ; 247
	i32 176, ; 248
	i32 242, ; 249
	i32 235, ; 250
	i32 64, ; 251
	i32 138, ; 252
	i32 15, ; 253
	i32 116, ; 254
	i32 274, ; 255
	i32 283, ; 256
	i32 230, ; 257
	i32 48, ; 258
	i32 70, ; 259
	i32 80, ; 260
	i32 126, ; 261
	i32 94, ; 262
	i32 121, ; 263
	i32 290, ; 264
	i32 26, ; 265
	i32 251, ; 266
	i32 97, ; 267
	i32 28, ; 268
	i32 226, ; 269
	i32 328, ; 270
	i32 306, ; 271
	i32 149, ; 272
	i32 169, ; 273
	i32 4, ; 274
	i32 98, ; 275
	i32 33, ; 276
	i32 93, ; 277
	i32 273, ; 278
	i32 185, ; 279
	i32 21, ; 280
	i32 41, ; 281
	i32 170, ; 282
	i32 322, ; 283
	i32 244, ; 284
	i32 314, ; 285
	i32 190, ; 286
	i32 179, ; 287
	i32 258, ; 288
	i32 289, ; 289
	i32 283, ; 290
	i32 263, ; 291
	i32 2, ; 292
	i32 134, ; 293
	i32 111, ; 294
	i32 186, ; 295
	i32 334, ; 296
	i32 213, ; 297
	i32 331, ; 298
	i32 58, ; 299
	i32 95, ; 300
	i32 196, ; 301
	i32 313, ; 302
	i32 39, ; 303
	i32 224, ; 304
	i32 25, ; 305
	i32 94, ; 306
	i32 89, ; 307
	i32 99, ; 308
	i32 10, ; 309
	i32 87, ; 310
	i32 100, ; 311
	i32 270, ; 312
	i32 181, ; 313
	i32 290, ; 314
	i32 215, ; 315
	i32 197, ; 316
	i32 310, ; 317
	i32 7, ; 318
	i32 255, ; 319
	i32 305, ; 320
	i32 212, ; 321
	i32 191, ; 322
	i32 88, ; 323
	i32 250, ; 324
	i32 154, ; 325
	i32 309, ; 326
	i32 33, ; 327
	i32 116, ; 328
	i32 82, ; 329
	i32 20, ; 330
	i32 11, ; 331
	i32 162, ; 332
	i32 3, ; 333
	i32 201, ; 334
	i32 317, ; 335
	i32 188, ; 336
	i32 186, ; 337
	i32 84, ; 338
	i32 294, ; 339
	i32 64, ; 340
	i32 319, ; 341
	i32 277, ; 342
	i32 143, ; 343
	i32 301, ; 344
	i32 259, ; 345
	i32 157, ; 346
	i32 195, ; 347
	i32 41, ; 348
	i32 117, ; 349
	i32 182, ; 350
	i32 214, ; 351
	i32 313, ; 352
	i32 266, ; 353
	i32 131, ; 354
	i32 75, ; 355
	i32 66, ; 356
	i32 323, ; 357
	i32 172, ; 358
	i32 300, ; 359
	i32 218, ; 360
	i32 143, ; 361
	i32 106, ; 362
	i32 151, ; 363
	i32 70, ; 364
	i32 156, ; 365
	i32 194, ; 366
	i32 181, ; 367
	i32 121, ; 368
	i32 127, ; 369
	i32 318, ; 370
	i32 152, ; 371
	i32 241, ; 372
	i32 141, ; 373
	i32 228, ; 374
	i32 315, ; 375
	i32 20, ; 376
	i32 14, ; 377
	i32 135, ; 378
	i32 75, ; 379
	i32 59, ; 380
	i32 231, ; 381
	i32 167, ; 382
	i32 168, ; 383
	i32 199, ; 384
	i32 15, ; 385
	i32 74, ; 386
	i32 6, ; 387
	i32 23, ; 388
	i32 253, ; 389
	i32 207, ; 390
	i32 212, ; 391
	i32 91, ; 392
	i32 316, ; 393
	i32 1, ; 394
	i32 136, ; 395
	i32 254, ; 396
	i32 276, ; 397
	i32 134, ; 398
	i32 69, ; 399
	i32 146, ; 400
	i32 325, ; 401
	i32 294, ; 402
	i32 245, ; 403
	i32 187, ; 404
	i32 88, ; 405
	i32 96, ; 406
	i32 235, ; 407
	i32 0, ; 408
	i32 240, ; 409
	i32 320, ; 410
	i32 31, ; 411
	i32 209, ; 412
	i32 45, ; 413
	i32 249, ; 414
	i32 194, ; 415
	i32 173, ; 416
	i32 211, ; 417
	i32 214, ; 418
	i32 109, ; 419
	i32 158, ; 420
	i32 35, ; 421
	i32 22, ; 422
	i32 174, ; 423
	i32 114, ; 424
	i32 57, ; 425
	i32 274, ; 426
	i32 144, ; 427
	i32 118, ; 428
	i32 120, ; 429
	i32 110, ; 430
	i32 216, ; 431
	i32 139, ; 432
	i32 222, ; 433
	i32 190, ; 434
	i32 54, ; 435
	i32 105, ; 436
	i32 326, ; 437
	i32 204, ; 438
	i32 200, ; 439
	i32 201, ; 440
	i32 133, ; 441
	i32 288, ; 442
	i32 279, ; 443
	i32 267, ; 444
	i32 332, ; 445
	i32 245, ; 446
	i32 203, ; 447
	i32 159, ; 448
	i32 296, ; 449
	i32 311, ; 450
	i32 232, ; 451
	i32 163, ; 452
	i32 132, ; 453
	i32 267, ; 454
	i32 161, ; 455
	i32 324, ; 456
	i32 256, ; 457
	i32 298, ; 458
	i32 140, ; 459
	i32 279, ; 460
	i32 275, ; 461
	i32 169, ; 462
	i32 202, ; 463
	i32 211, ; 464
	i32 176, ; 465
	i32 217, ; 466
	i32 284, ; 467
	i32 40, ; 468
	i32 243, ; 469
	i32 81, ; 470
	i32 56, ; 471
	i32 37, ; 472
	i32 97, ; 473
	i32 166, ; 474
	i32 172, ; 475
	i32 280, ; 476
	i32 82, ; 477
	i32 219, ; 478
	i32 98, ; 479
	i32 30, ; 480
	i32 159, ; 481
	i32 206, ; 482
	i32 18, ; 483
	i32 127, ; 484
	i32 119, ; 485
	i32 239, ; 486
	i32 270, ; 487
	i32 252, ; 488
	i32 206, ; 489
	i32 272, ; 490
	i32 165, ; 491
	i32 302, ; 492
	i32 247, ; 493
	i32 209, ; 494
	i32 339, ; 495
	i32 269, ; 496
	i32 260, ; 497
	i32 170, ; 498
	i32 16, ; 499
	i32 144, ; 500
	i32 317, ; 501
	i32 197, ; 502
	i32 125, ; 503
	i32 118, ; 504
	i32 38, ; 505
	i32 115, ; 506
	i32 47, ; 507
	i32 142, ; 508
	i32 117, ; 509
	i32 34, ; 510
	i32 178, ; 511
	i32 304, ; 512
	i32 95, ; 513
	i32 53, ; 514
	i32 261, ; 515
	i32 129, ; 516
	i32 153, ; 517
	i32 24, ; 518
	i32 161, ; 519
	i32 238, ; 520
	i32 148, ; 521
	i32 104, ; 522
	i32 89, ; 523
	i32 226, ; 524
	i32 60, ; 525
	i32 142, ; 526
	i32 297, ; 527
	i32 301, ; 528
	i32 100, ; 529
	i32 5, ; 530
	i32 13, ; 531
	i32 122, ; 532
	i32 135, ; 533
	i32 28, ; 534
	i32 312, ; 535
	i32 193, ; 536
	i32 72, ; 537
	i32 236, ; 538
	i32 24, ; 539
	i32 224, ; 540
	i32 297, ; 541
	i32 265, ; 542
	i32 262, ; 543
	i32 329, ; 544
	i32 137, ; 545
	i32 217, ; 546
	i32 233, ; 547
	i32 168, ; 548
	i32 195, ; 549
	i32 266, ; 550
	i32 308, ; 551
	i32 101, ; 552
	i32 123, ; 553
	i32 237, ; 554
	i32 183, ; 555
	i32 163, ; 556
	i32 167, ; 557
	i32 240, ; 558
	i32 39, ; 559
	i32 198, ; 560
	i32 316, ; 561
	i32 17, ; 562
	i32 171, ; 563
	i32 329, ; 564
	i32 328, ; 565
	i32 137, ; 566
	i32 150, ; 567
	i32 229, ; 568
	i32 155, ; 569
	i32 130, ; 570
	i32 19, ; 571
	i32 65, ; 572
	i32 180, ; 573
	i32 295, ; 574
	i32 205, ; 575
	i32 147, ; 576
	i32 173, ; 577
	i32 47, ; 578
	i32 210, ; 579
	i32 336, ; 580
	i32 215, ; 581
	i32 79, ; 582
	i32 61, ; 583
	i32 106, ; 584
	i32 264, ; 585
	i32 219, ; 586
	i32 49, ; 587
	i32 250, ; 588
	i32 333, ; 589
	i32 261, ; 590
	i32 14, ; 591
	i32 182, ; 592
	i32 68, ; 593
	i32 171, ; 594
	i32 225, ; 595
	i32 229, ; 596
	i32 338, ; 597
	i32 192, ; 598
	i32 78, ; 599
	i32 234, ; 600
	i32 108, ; 601
	i32 218, ; 602
	i32 260, ; 603
	i32 67, ; 604
	i32 63, ; 605
	i32 27, ; 606
	i32 160, ; 607
	i32 227, ; 608
	i32 10, ; 609
	i32 198, ; 610
	i32 11, ; 611
	i32 303, ; 612
	i32 175, ; 613
	i32 78, ; 614
	i32 126, ; 615
	i32 83, ; 616
	i32 184, ; 617
	i32 66, ; 618
	i32 296, ; 619
	i32 107, ; 620
	i32 65, ; 621
	i32 128, ; 622
	i32 122, ; 623
	i32 77, ; 624
	i32 275, ; 625
	i32 265, ; 626
	i32 337, ; 627
	i32 8, ; 628
	i32 233, ; 629
	i32 2, ; 630
	i32 44, ; 631
	i32 278, ; 632
	i32 156, ; 633
	i32 128, ; 634
	i32 263, ; 635
	i32 23, ; 636
	i32 133, ; 637
	i32 221, ; 638
	i32 252, ; 639
	i32 332, ; 640
	i32 314, ; 641
	i32 29, ; 642
	i32 220, ; 643
	i32 62, ; 644
	i32 200, ; 645
	i32 90, ; 646
	i32 87, ; 647
	i32 148, ; 648
	i32 202, ; 649
	i32 36, ; 650
	i32 86, ; 651
	i32 241, ; 652
	i32 327, ; 653
	i32 0, ; 654
	i32 322, ; 655
	i32 183, ; 656
	i32 50, ; 657
	i32 6, ; 658
	i32 90, ; 659
	i32 334, ; 660
	i32 21, ; 661
	i32 162, ; 662
	i32 96, ; 663
	i32 50, ; 664
	i32 113, ; 665
	i32 257, ; 666
	i32 130, ; 667
	i32 76, ; 668
	i32 27, ; 669
	i32 234, ; 670
	i32 300, ; 671
	i32 256, ; 672
	i32 7, ; 673
	i32 208, ; 674
	i32 199, ; 675
	i32 177, ; 676
	i32 110, ; 677
	i32 257, ; 678
	i32 243 ; 679
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 0d97e20b84d8e87c3502469ee395805907905fe3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
