﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace net.elfmission.WindowsApps.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("net.elfmission.WindowsApps.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   パラメータ containerはIelfDynamicViewContainerをインプリメントしたControlを指定してください。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string EXP_CONTAINER_IS_NOT_DYNAMIC_VIEW_CONTAINER {
            get {
                return ResourceManager.GetString("EXP_CONTAINER_IS_NOT_DYNAMIC_VIEW_CONTAINER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   パラメータ containerのオブジェクト参照が存在しません。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string EXP_CONTAINER_IS_NULL {
            get {
                return ResourceManager.GetString("EXP_CONTAINER_IS_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   WantDynamicViewイベントがされていないか、WantDynamicViewEventArgs.Viewに表示したいDynamicViewを設定してください。 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string EXP_WantDynamicView_EVENT_NOT_IMPLEMENT {
            get {
                return ResourceManager.GetString("EXP_WantDynamicView_EVENT_NOT_IMPLEMENT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   エラー に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string MsgBoxTitleError {
            get {
                return ResourceManager.GetString("MsgBoxTitleError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   情報 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string MsgBoxTitleInformation {
            get {
                return ResourceManager.GetString("MsgBoxTitleInformation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   問い合わせ に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string MsgBoxTitleQuestion {
            get {
                return ResourceManager.GetString("MsgBoxTitleQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   警告 に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string MsgBoxTitleWarning {
            get {
                return ResourceManager.GetString("MsgBoxTitleWarning", resourceCulture);
            }
        }
    }
}
