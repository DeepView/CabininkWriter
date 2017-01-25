using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
namespace Cabinink.Writer.Cores
{
   /// <summary>
   /// 用于定义 Windows 系统级别的快捷键的类
   /// </summary>
   /// <example>
   /// 下面的示例是使用 GlobalShortcutKey 类来进行快捷键注册和注销，当然一定要注意的是，当前示例程序窗体（甚至其他的应用程序窗体）需要重载窗口处理函数void WndProc(ref Message m)，当快捷键信息传到到窗口时，需要对相应的信息进行处理。
   /// <code>
   /// public partial class Form1 : Form
   /// {
   ///     HotKeys h = new HotKeys();
   ///    public Form1()
   ///    {
   ///       InitializeComponent();
   ///    }
   ///    private void btnRegist_Click(object sender, EventArgs e)
   ///    {
   ///       //这里注册了Ctrl+Alt+E 快捷键
   ///       h.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Control + (int)HotKeys.HotkeyModifiers.Alt, Keys.E, CallBack);
   ///       MessageBox.Show("注册成功");
   ///    }
   ///    private void btnUnregist_Click(object sender, EventArgs e)
   ///    {
   ///       h.UnRegist(this.Handle, CallBack);
   ///       MessageBox.Show("卸载成功");
   ///    }
   ///    protected override void WndProc(ref Message m)
   ///    {
   ///       //窗口消息处理函数
   ///       h.ProcessHotKey(m);
   ///       base.WndProc(ref m);
   ///    }
   ///    //按下快捷键时被调用的方法
   ///    public void CallBack()
   ///    {
   ///       MessageBox.Show("快捷键被调用！");
   ///    }
   /// }
   /// </code>
   /// </example>
   public class GlobalShortcutKey
   {
      /// <summary>
      /// 当用户按指定函数注册热键时，这则消息被发布。该消息放置在与注册热键的线程关联的消息队列的顶端
      /// </summary>
      private const int WM_HOTKEY = 0x312;
      /// <summary>
      /// 按键ID
      /// </summary>
      private static int keyid = 10;
      /// <summary>
      /// 按键集
      /// </summary>
      private static Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();
      /// <summary>
      /// 注册/注销热键的回调函数委托
      /// </summary>
      public delegate void HotKeyCallBackHanlder();
      /// <summary>
      /// 定义系统范围的热键
      /// </summary>
      /// <param name="hWnd">接收热键产生WM_HOTKEY消息的窗口句柄。若该参数NULL，传递给调用线程的WM_HOTKEY消息必须在消息循环中进行处理。</param>
      /// <param name="id">定义热键的标识符。调用线程中的其他热键，不能使用同样的标识符。应用程序必须定义一个0X0000-0xBFFF范围的值。一个共享的动态链接库（DLL）必须定义一个范围为0xC000-0xFFFF的值(GlobalAddAtom函数返回该范围）。为了避免与其他动态链接库定义的热键冲突，一个DLL必须使用GlobalAddAtom函数获得热键的标识符。</param>
      /// <param name="fsModifiers">定义为了产生WM_HOTKEY消息而必须与由nVirtKey参数定义的键一起按下的键。该参数可以是如下值的组合：Alter：0x0001，按下的可以是任一Alt键；Shift：0x0004，按下的可以是任一Shift键。Windows：0x0008，按下的可以是任一Windows徽标键。Norepeat：0x4000，更改热键行为，以便键盘自动重复不会产生多个热键通知。Control：0x0002，按下的可以是任一Ctrl键。 </param>
      /// <param name="vk">定义热键的虚拟键码。</param>
      /// <returns>若函数调用成功，返回一个非0值。若函数调用失败，则返回值为0。</returns>
      /// <remarks>该函数定义一个系统范围的热键。函数原型：BOOL RegisterHotKey（HWND hWnd，int id，UINT fsModifiers，UINT vk）;若要获得更多的错误信息，可以调用GetLastError函数。当某键被接下时，系统在所有的热键中寻找匹配者。一旦找到一个匹配的热键，系统将把WM_HOTKEY消息传递给登记了该热键的线程的消息队列。该消息被传送到队列头部，因此它将在下一轮消息循环中被移去。该函数不能将热键同其他线程创建的窗口关联起来。若为一热键定义的击键己被其他热键所定义，则RegisterHotKey函数调用失败。若hWnd参数标识的窗口已用与id参数定义的相同的标识符登记了一个热键，则参数fsModifiers和vk的新值将替代这些参数先前定义的值。Windows CE：Windows CE 2.0以上版本对于参数fsModifiers支持一个附加的标志位。叫做MOD_KEYUP。若设置MOD_KEYUP位，则当发生键被按下或被弹起的事件时，窗口将发送WM_HOTKEY消息。RegisterHotKey可以被用来在线程之间登记热键。</remarks>
      [DllImport("user32.dll")]
      protected static extern uint RegisterHotKey(IntPtr hWnd, uint id, uint fsModifiers, uint vk);
      /// <summary>
      /// 释放调用线程先前登记的热键
      /// </summary>
      /// <param name="hWnd">与被释放的热键相关的窗口句柄。若热键不与窗口相关，则该参数为NULL。</param>
      /// <param name="id">定义被释放的热键的标识符。</param>
      /// <returns>若函数调用成功，返回值不为0。若函数调用失败，返回值为0。</returns>
      /// <remarks>释放调用线程先前登记的热键。若要获得更多的错误信息，可以调用GetLastError函数。</remarks>
      [DllImport("user32.dll", SetLastError = true)]
      protected static extern bool UnregisterHotKey(IntPtr hWnd, int id);
      /// <summary> 
      /// 注册快捷键 
      /// </summary> 
      /// <param name="_handle">持有快捷键窗口的句柄。</param> 
      /// <param name="_fsModifiers">组合键。</param> 
      /// <param name="_vk">快捷键的虚拟键码。</param> 
      /// <param name="_callback">回调函数 HotKeyCallBackHanlder。</param> 
      public static void Regist(IntPtr _handle, EHotkeyModifiers _fsModifiers, Keys _vk, HotKeyCallBackHanlder _callback)
      {
         int id = Math.Max(Interlocked.Increment(ref keyid), keyid - 1);
         if (RegisterHotKey(_handle, (uint)id, (uint)_fsModifiers, (uint)_vk) != 0)
         {
            throw new RegistHotkeyFailException("全局热键注册失败！");
         }
         keymap[id] = _callback;
      }
      /// <summary> 
      /// 注销快捷键 
      /// </summary> 
      /// <param name="_handle">持有快捷键窗口的句柄。</param> 
      /// <param name="_callback">回调函数 HotKeyCallBackHanlder。</param> 
      public static void Unregist(IntPtr _handle, HotKeyCallBackHanlder _callback)
      {
         foreach (KeyValuePair<int, HotKeyCallBackHanlder> var in keymap)
         {
            if (var.Value == _callback)
            {
               UnregisterHotKey(_handle, var.Key);
               break;
            }
         }
      }
      /// <summary> 
      /// 快捷键消息处理
      /// </summary> 
      /// <param name="_msg">需要处理的消息。</param>
      public static void ProcessHotKey(Message _msg)
      {
         if (_msg.Msg == WM_HOTKEY)
         {
            int id = _msg.WParam.ToInt32();
            HotKeyCallBackHanlder callback;
            if (keymap.TryGetValue(id, out callback)) callback();
         }
      }
   }
   /// <summary>
   /// 快捷键的高频按键枚举
   /// </summary>
   public enum EHotkeyModifiers : int
   {
      /// <summary>
      /// 交替换档键ALT
      /// </summary>
      Alter = 1,
      /// <summary>
      /// 控制键CTRL
      /// </summary>
      Control = 2,
      /// <summary>
      /// 第二功能键SHIFT
      /// </summary>
      Shift = 4,
      /// <summary>
      /// Windows按键WIN
      /// </summary>
      Windows = 8,
      /// <summary>
      /// 更改热键行为，以便键盘自动重复不会产生多个热键通知。
      /// </summary>
      Norepeat = 16384
   }
   /// <summary>
   /// 全局快捷键注册失败时抛出的异常
   /// </summary>
   [Serializable]
   public class RegistHotkeyFailException : Exception
   {
      public RegistHotkeyFailException() { }
      public RegistHotkeyFailException(string message) : base(message) { }
      public RegistHotkeyFailException(string message, Exception inner) : base(message, inner) { }
      protected RegistHotkeyFailException(SerializationInfo info, StreamingContext context) : base(info, context) { }
   }
}
