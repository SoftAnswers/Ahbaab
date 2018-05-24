using Android.App;
using Android.App.Assist;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Database;
using Android.Database.Sqlite;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Transitions;
using Android.Util;
using Android.Views;
using Android.Views.Accessibility;
using Java.Interop;
using Java.IO;
using Java.Lang;
using System;
using System.IO;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace Asawer.Droid
{
    [Activity]
    public abstract class AsawerAppCompatActivity : AppCompatActivity
    {
        private NavigationView navigationView;

        private DrawerLayout drawerLayout;

        public NavigationView NavigationView
        {
            get
            {
                return this.navigationView;
            }
        }

        public DrawerLayout DrawerLayout
        {
            get
            {
                return this.drawerLayout;
            }
        }

        public AsawerAppCompatActivity()
        {
        }

        protected AsawerAppCompatActivity(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override bool IsRestricted => base.IsRestricted;

        public override Context ApplicationContext => base.ApplicationContext;

        public override ApplicationInfo ApplicationInfo => base.ApplicationInfo;

        public override AssetManager Assets => base.Assets;

        public override Context BaseContext => base.BaseContext;

        public override Java.IO.File CacheDir => base.CacheDir;

        public override ClassLoader ClassLoader => base.ClassLoader;

        public override Java.IO.File CodeCacheDir => base.CodeCacheDir;

        public override ContentResolver ContentResolver => base.ContentResolver;

        public override Java.IO.File ExternalCacheDir => base.ExternalCacheDir;

        public override Java.IO.File FilesDir => base.FilesDir;

        public override Looper MainLooper => base.MainLooper;

        public override Java.IO.File NoBackupFilesDir => base.NoBackupFilesDir;

        public override Java.IO.File ObbDir => base.ObbDir;

        public override string PackageCodePath => base.PackageCodePath;

        public override PackageManager PackageManager => base.PackageManager;

        public override string PackageName => base.PackageName;

        public override string PackageResourcePath => base.PackageResourcePath;

        public override Resources.Theme Theme => base.Theme;

        public override Drawable Wallpaper => base.Wallpaper;

        public override int WallpaperDesiredMinimumHeight => base.WallpaperDesiredMinimumHeight;

        public override int WallpaperDesiredMinimumWidth => base.WallpaperDesiredMinimumWidth;

        public override JniPeerMembers JniPeerMembers => base.JniPeerMembers;

        public override Android.App.ActionBar ActionBar => base.ActionBar;

        public override ComponentName CallingActivity => base.CallingActivity;

        public override string CallingPackage => base.CallingPackage;

        public override ConfigChanges ChangingConfigurations => base.ChangingConfigurations;

        public override ComponentName ComponentName => base.ComponentName;

        public override Scene ContentScene => base.ContentScene;

        public override TransitionManager ContentTransitionManager { get => base.ContentTransitionManager; set => base.ContentTransitionManager = value; }

        public override View CurrentFocus => base.CurrentFocus;

        public override Android.App.FragmentManager FragmentManager => base.FragmentManager;

        public override bool HasWindowFocus => base.HasWindowFocus;

        public override bool Immersive { get => base.Immersive; set => base.Immersive = value; }
        public override Intent Intent { get => base.Intent; set => base.Intent = value; }

        public override bool IsChangingConfigurations => base.IsChangingConfigurations;

        public override bool IsDestroyed => base.IsDestroyed;

        public override bool IsFinishing => base.IsFinishing;

        public override bool IsTaskRoot => base.IsTaskRoot;

        public override bool IsVoiceInteraction => base.IsVoiceInteraction;

        public override bool IsVoiceInteractionRoot => base.IsVoiceInteractionRoot;

        public override Java.Lang.Object LastNonConfigurationInstance => base.LastNonConfigurationInstance;

        public override LayoutInflater LayoutInflater => base.LayoutInflater;

        public override Android.App.LoaderManager LoaderManager => base.LoaderManager;

        public override string LocalClassName => base.LocalClassName;

        public override Intent ParentActivityIntent => base.ParentActivityIntent;

        public override Android.Net.Uri Referrer => base.Referrer;

        public override ScreenOrientation RequestedOrientation { get => base.RequestedOrientation; set => base.RequestedOrientation = value; }

        public override int TaskId => base.TaskId;

        public override VoiceInteractor VoiceInteractor => base.VoiceInteractor;

        public override Window Window => base.Window;

        public override IWindowManager WindowManager => base.WindowManager;

        public override Java.Lang.Object LastCustomNonConfigurationInstance => base.LastCustomNonConfigurationInstance;

        public override Android.Support.V4.App.FragmentManager SupportFragmentManager => base.SupportFragmentManager;

        public override Android.Support.V4.App.LoaderManager SupportLoaderManager => base.SupportLoaderManager;

        public override AppCompatDelegate Delegate => base.Delegate;

        public override Android.Support.V7.App.ActionBarDrawerToggle.IDelegate DrawerToggleDelegate => base.DrawerToggleDelegate;

        public override MenuInflater MenuInflater => base.MenuInflater;

        public override Resources Resources => base.Resources;

        public override Android.Support.V7.App.ActionBar SupportActionBar => base.SupportActionBar;

        public override Intent SupportParentActivityIntent => base.SupportParentActivityIntent;

        protected override IntPtr ThresholdClass => base.ThresholdClass;

        protected override Type ThresholdType => base.ThresholdType;

        public override void AddContentView(View view, ViewGroup.LayoutParams @params)
        {
            base.AddContentView(view, @params);
        }

        public override void ApplyOverrideConfiguration(Configuration overrideConfiguration)
        {
            base.ApplyOverrideConfiguration(overrideConfiguration);
        }

        public override bool BindService(Intent service, IServiceConnection conn, [GeneratedEnum] Bind flags)
        {
            return base.BindService(service, conn, flags);
        }

        public override Permission CheckCallingOrSelfPermission(string permission)
        {
            return base.CheckCallingOrSelfPermission(permission);
        }

        public override Permission CheckCallingOrSelfUriPermission(Android.Net.Uri uri, [GeneratedEnum] ActivityFlags modeFlags)
        {
            return base.CheckCallingOrSelfUriPermission(uri, modeFlags);
        }

        public override Permission CheckCallingPermission(string permission)
        {
            return base.CheckCallingPermission(permission);
        }

        public override Permission CheckCallingUriPermission(Android.Net.Uri uri, [GeneratedEnum] ActivityFlags modeFlags)
        {
            return base.CheckCallingUriPermission(uri, modeFlags);
        }

        public override Permission CheckPermission(string permission, int pid, int uid)
        {
            return base.CheckPermission(permission, pid, uid);
        }

        [return: GeneratedEnum]
        public override Permission CheckSelfPermission(string permission)
        {
            return base.CheckSelfPermission(permission);
        }

        public override Permission CheckUriPermission(Android.Net.Uri uri, int pid, int uid, [GeneratedEnum] ActivityFlags modeFlags)
        {
            return base.CheckUriPermission(uri, pid, uid, modeFlags);
        }

        public override Permission CheckUriPermission(Android.Net.Uri uri, string readPermission, string writePermission, int pid, int uid, [GeneratedEnum] ActivityFlags modeFlags)
        {
            return base.CheckUriPermission(uri, readPermission, writePermission, pid, uid, modeFlags);
        }

        public override void ClearWallpaper()
        {
            base.ClearWallpaper();
        }

        public override void CloseContextMenu()
        {
            base.CloseContextMenu();
        }

        public override void CloseOptionsMenu()
        {
            base.CloseOptionsMenu();
        }

        public override Context CreateConfigurationContext(Configuration overrideConfiguration)
        {
            return base.CreateConfigurationContext(overrideConfiguration);
        }

        public override Context CreateDisplayContext(Display display)
        {
            return base.CreateDisplayContext(display);
        }

        public override Context CreatePackageContext(string packageName, [GeneratedEnum] PackageContextFlags flags)
        {
            return base.CreatePackageContext(packageName, flags);
        }

        public override PendingIntent CreatePendingResult(int requestCode, Intent data, [GeneratedEnum] PendingIntentFlags flags)
        {
            return base.CreatePendingResult(requestCode, data, flags);
        }

        public override string[] DatabaseList()
        {
            return base.DatabaseList();
        }

        public override bool DeleteDatabase(string name)
        {
            return base.DeleteDatabase(name);
        }

        public override bool DeleteFile(string name)
        {
            return base.DeleteFile(name);
        }

        public override bool DispatchGenericMotionEvent(MotionEvent ev)
        {
            return base.DispatchGenericMotionEvent(ev);
        }

        public override bool DispatchKeyEvent(KeyEvent @event)
        {
            return base.DispatchKeyEvent(@event);
        }

        public override bool DispatchKeyShortcutEvent(KeyEvent e)
        {
            return base.DispatchKeyShortcutEvent(e);
        }

        public override bool DispatchPopulateAccessibilityEvent(AccessibilityEvent e)
        {
            return base.DispatchPopulateAccessibilityEvent(e);
        }

        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            return base.DispatchTouchEvent(ev);
        }

        public override bool DispatchTrackballEvent(MotionEvent ev)
        {
            return base.DispatchTrackballEvent(ev);
        }

        public override void Dump(string prefix, FileDescriptor fd, PrintWriter writer, string[] args)
        {
            base.Dump(prefix, fd, writer, args);
        }

        public override void EnforceCallingOrSelfPermission(string permission, string message)
        {
            base.EnforceCallingOrSelfPermission(permission, message);
        }

        public override void EnforceCallingOrSelfUriPermission(Android.Net.Uri uri, [GeneratedEnum] ActivityFlags modeFlags, string message)
        {
            base.EnforceCallingOrSelfUriPermission(uri, modeFlags, message);
        }

        public override void EnforceCallingPermission(string permission, string message)
        {
            base.EnforceCallingPermission(permission, message);
        }

        public override void EnforceCallingUriPermission(Android.Net.Uri uri, [GeneratedEnum] ActivityFlags modeFlags, string message)
        {
            base.EnforceCallingUriPermission(uri, modeFlags, message);
        }

        public override void EnforcePermission(string permission, int pid, int uid, string message)
        {
            base.EnforcePermission(permission, pid, uid, message);
        }

        public override void EnforceUriPermission(Android.Net.Uri uri, int pid, int uid, [GeneratedEnum] ActivityFlags modeFlags, string message)
        {
            base.EnforceUriPermission(uri, pid, uid, modeFlags, message);
        }

        public override void EnforceUriPermission(Android.Net.Uri uri, string readPermission, string writePermission, int pid, int uid, [GeneratedEnum] ActivityFlags modeFlags, string message)
        {
            base.EnforceUriPermission(uri, readPermission, writePermission, pid, uid, modeFlags, message);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override bool Equals(Java.Lang.Object o)
        {
            return base.Equals(o);
        }

        public override string[] FileList()
        {
            return base.FileList();
        }

        public override View FindViewById(int id)
        {
            return base.FindViewById(id);
        }

        public override void Finish()
        {
            base.Finish();
        }

        public override void FinishActivity(int requestCode)
        {
            base.FinishActivity(requestCode);
        }

        public override void FinishActivityFromChild(Activity child, int requestCode)
        {
            base.FinishActivityFromChild(child, requestCode);
        }

        public override void FinishAffinity()
        {
            base.FinishAffinity();
        }

        public override void FinishAfterTransition()
        {
            base.FinishAfterTransition();
        }

        public override void FinishAndRemoveTask()
        {
            base.FinishAndRemoveTask();
        }

        public override void FinishFromChild(Activity child)
        {
            base.FinishFromChild(child);
        }

        public override Java.IO.File GetDatabasePath(string name)
        {
            return base.GetDatabasePath(name);
        }

        public override Java.IO.File GetDir(string name, [GeneratedEnum] FileCreationMode mode)
        {
            return base.GetDir(name, mode);
        }

        public override Java.IO.File[] GetExternalCacheDirs()
        {
            return base.GetExternalCacheDirs();
        }

        public override Java.IO.File GetExternalFilesDir(string type)
        {
            return base.GetExternalFilesDir(type);
        }

        public override Java.IO.File[] GetExternalFilesDirs(string type)
        {
            return base.GetExternalFilesDirs(type);
        }

        public override Java.IO.File[] GetExternalMediaDirs()
        {
            return base.GetExternalMediaDirs();
        }

        public override Java.IO.File GetFileStreamPath(string name)
        {
            return base.GetFileStreamPath(name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Java.IO.File[] GetObbDirs()
        {
            return base.GetObbDirs();
        }

        public override ISharedPreferences GetPreferences([GeneratedEnum] FileCreationMode mode)
        {
            return base.GetPreferences(mode);
        }

        public override ISharedPreferences GetSharedPreferences(string name, [GeneratedEnum] FileCreationMode mode)
        {
            return base.GetSharedPreferences(name, mode);
        }

        public override Java.Lang.Object GetSystemService([StringDef(Type = "Android.Content.Context", Fields = new[] { "PowerService", "WindowService", "LayoutInflaterService", "AccountService", "ActivityService", "AlarmService", "NotificationService", "AccessibilityService", "CaptioningService", "KeyguardService", "LocationService", "SearchService", "SensorService", "StorageService", "WallpaperService", "VibratorService", "ConnectivityService", "NetworkStatsService", "WifiService", "WifiP2pService", "NsdService", "AudioService", "FingerprintService", "MediaRouterService", "TelephonyService", "TelephonySubscriptionService", "CarrierConfigService", "TelecomService", "ClipboardService", "InputMethodService", "TextServicesManagerService", "AppwidgetService", "DropboxService", "DevicePolicyService", "UiModeService", "DownloadService", "NfcService", "BluetoothService", "UsbService", "LauncherAppsService", "InputService", "DisplayService", "UserService", "RestrictionsService", "AppOpsService", "CameraService", "PrintService", "ConsumerIrService", "TvInputService", "UsageStatsService", "MediaSessionService", "BatteryService", "JobSchedulerService", "MediaProjectionService", "MidiService" }), StringDef(Type = "", Fields = new[] { "", "", "" }), StringDef(Type = "Android.Content.Context", Fields = new[] { "PowerService", "WindowService", "LayoutInflaterService", "AccountService", "ActivityService", "AlarmService", "NotificationService", "AccessibilityService", "CaptioningService", "KeyguardService", "LocationService", "SearchService", "SensorService", "StorageService", "WallpaperService", "VibratorService", "ConnectivityService", "NetworkStatsService", "WifiService", "WifiP2pService", "NsdService", "AudioService", "FingerprintService", "MediaRouterService", "TelephonyService", "TelephonySubscriptionService", "CarrierConfigService", "TelecomService", "ClipboardService", "InputMethodService", "TextServicesManagerService", "AppwidgetService", "DropboxService", "DevicePolicyService", "UiModeService", "DownloadService", "NfcService", "BluetoothService", "UsbService", "LauncherAppsService", "InputService", "DisplayService", "UserService", "RestrictionsService", "AppOpsService", "CameraService", "PrintService", "ConsumerIrService", "TvInputService", "UsageStatsService", "MediaSessionService", "BatteryService", "JobSchedulerService", "MediaProjectionService", "MidiService" }), StringDef(Type = "", Fields = new[] { "", "", "" })] string name)
        {
            return base.GetSystemService(name);
        }

        public override string GetSystemServiceName(Class serviceClass)
        {
            return base.GetSystemServiceName(serviceClass);
        }

        public override void GrantUriPermission(string toPackage, Android.Net.Uri uri, [GeneratedEnum] ActivityFlags modeFlags)
        {
            base.GrantUriPermission(toPackage, uri, modeFlags);
        }

        public override void InvalidateOptionsMenu()
        {
            base.InvalidateOptionsMenu();
        }

        public override bool MoveTaskToBack(bool nonRoot)
        {
            return base.MoveTaskToBack(nonRoot);
        }

        public override bool NavigateUpTo(Intent upIntent)
        {
            return base.NavigateUpTo(upIntent);
        }

        public override bool NavigateUpToFromChild(Activity child, Intent upIntent)
        {
            return base.NavigateUpToFromChild(child, upIntent);
        }

        public override void OnActionModeFinished(Android.Views.ActionMode mode)
        {
            base.OnActionModeFinished(mode);
        }

        public override void OnActionModeStarted(Android.Views.ActionMode mode)
        {
            base.OnActionModeStarted(mode);
        }

        public override void OnActivityReenter(int resultCode, Intent data)
        {
            base.OnActivityReenter(resultCode, data);
        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
        }

        public override void OnAttachFragment(Android.App.Fragment fragment)
        {
            base.OnAttachFragment(fragment);
        }

        public override void OnAttachFragment(Android.Support.V4.App.Fragment fragment)
        {
            base.OnAttachFragment(fragment);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
        }

        public override void OnContentChanged()
        {
            base.OnContentChanged();
        }

        public override bool OnContextItemSelected(IMenuItem item)
        {
            return base.OnContextItemSelected(item);
        }

        public override void OnContextMenuClosed(IMenu menu)
        {
            base.OnContextMenuClosed(menu);
        }

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            base.OnCreateContextMenu(menu, v, menuInfo);
        }

        public override ICharSequence OnCreateDescriptionFormatted()
        {
            return base.OnCreateDescriptionFormatted();
        }

        public override void OnCreateNavigateUpTaskStack(TaskStackBuilder builder)
        {
            base.OnCreateNavigateUpTaskStack(builder);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnCreatePanelMenu(int featureId, IMenu menu)
        {
            return base.OnCreatePanelMenu(featureId, menu);
        }

        public override View OnCreatePanelView(int featureId)
        {
            return base.OnCreatePanelView(featureId);
        }

        public override void OnCreateSupportNavigateUpTaskStack(Android.Support.V4.App.TaskStackBuilder builder)
        {
            base.OnCreateSupportNavigateUpTaskStack(builder);
        }

        public override bool OnCreateThumbnail(Bitmap outBitmap, Canvas canvas)
        {
            return base.OnCreateThumbnail(outBitmap, canvas);
        }

        public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            return base.OnCreateView(parent, name, context, attrs);
        }

        public override View OnCreateView(string name, Context context, IAttributeSet attrs)
        {
            return base.OnCreateView(name, context, attrs);
        }

        public override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
        }

        public override void OnEnterAnimationComplete()
        {
            base.OnEnterAnimationComplete();
        }

        public override bool OnGenericMotionEvent(MotionEvent e)
        {
            return base.OnGenericMotionEvent(e);
        }

        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return base.OnKeyDown(keyCode, e);
        }

        public override bool OnKeyLongPress([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return base.OnKeyLongPress(keyCode, e);
        }

        public override bool OnKeyMultiple([GeneratedEnum] Keycode keyCode, int repeatCount, KeyEvent e)
        {
            return base.OnKeyMultiple(keyCode, repeatCount, e);
        }

        public override bool OnKeyShortcut([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return base.OnKeyShortcut(keyCode, e);
        }

        public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return base.OnKeyUp(keyCode, e);
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
        }

        public override bool OnMenuOpened(int featureId, IMenu menu)
        {
            return base.OnMenuOpened(featureId, menu);
        }

        [Obsolete]
        public override void OnMultiWindowModeChanged(bool isInMultiWindowMode)
        {
            base.OnMultiWindowModeChanged(isInMultiWindowMode);
        }

        public override bool OnNavigateUp()
        {
            return base.OnNavigateUp();
        }

        public override bool OnNavigateUpFromChild(Activity child)
        {
            return base.OnNavigateUpFromChild(child);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    this.DrawerLayout.OpenDrawer((int)GravityFlags.Right);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnOptionsMenuClosed(IMenu menu)
        {
            base.OnOptionsMenuClosed(menu);
        }

        public override void OnPanelClosed(int featureId, IMenu menu)
        {
            base.OnPanelClosed(featureId, menu);
        }

        [Obsolete]
        public override void OnPictureInPictureModeChanged(bool isInPictureInPictureMode)
        {
            base.OnPictureInPictureModeChanged(isInPictureInPictureMode);
        }

        public override void OnPostCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnPostCreate(savedInstanceState, persistentState);
        }

        public override void OnPrepareNavigateUpTaskStack(Android.App.TaskStackBuilder builder)
        {
            base.OnPrepareNavigateUpTaskStack(builder);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnPreparePanel(int featureId, View view, IMenu menu)
        {
            return base.OnPreparePanel(featureId, view, menu);
        }

        public override void OnPrepareSupportNavigateUpTaskStack(Android.Support.V4.App.TaskStackBuilder builder)
        {
            base.OnPrepareSupportNavigateUpTaskStack(builder);
        }

        public override void OnProvideAssistContent(AssistContent outContent)
        {
            base.OnProvideAssistContent(outContent);
        }

        public override void OnProvideAssistData(Bundle data)
        {
            base.OnProvideAssistData(data);
        }

        public override Android.Net.Uri OnProvideReferrer()
        {
            return base.OnProvideReferrer();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnRestoreInstanceState(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnRestoreInstanceState(savedInstanceState, persistentState);
        }

        public override Java.Lang.Object OnRetainCustomNonConfigurationInstance()
        {
            return base.OnRetainCustomNonConfigurationInstance();
        }

        public override void OnSaveInstanceState(Bundle outState, PersistableBundle outPersistentState)
        {
            base.OnSaveInstanceState(outState, outPersistentState);
        }

        public override bool OnSearchRequested()
        {
            return base.OnSearchRequested();
        }

        public override bool OnSearchRequested(SearchEvent searchEvent)
        {
            return base.OnSearchRequested(searchEvent);
        }

        public override void OnStateNotSaved()
        {
            base.OnStateNotSaved();
        }

        public override void OnSupportActionModeFinished(Android.Support.V7.View.ActionMode mode)
        {
            base.OnSupportActionModeFinished(mode);
        }

        public override void OnSupportActionModeStarted(Android.Support.V7.View.ActionMode mode)
        {
            base.OnSupportActionModeStarted(mode);
        }

        [Obsolete]
        public override void OnSupportContentChanged()
        {
            base.OnSupportContentChanged();
        }

        public override bool OnSupportNavigateUp()
        {
            return base.OnSupportNavigateUp();
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return base.OnTouchEvent(e);
        }

        public override bool OnTrackballEvent(MotionEvent e)
        {
            return base.OnTrackballEvent(e);
        }

        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            base.OnTrimMemory(level);
        }

        public override void OnUserInteraction()
        {
            base.OnUserInteraction();
        }

        [Obsolete]
        public override void OnVisibleBehindCanceled()
        {
            base.OnVisibleBehindCanceled();
        }

        public override void OnWindowAttributesChanged(WindowManagerLayoutParams @params)
        {
            base.OnWindowAttributesChanged(@params);
        }

        public override void OnWindowFocusChanged(bool hasFocus)
        {
            base.OnWindowFocusChanged(hasFocus);
        }

        public override ActionMode OnWindowStartingActionMode(ActionMode.ICallback callback)
        {
            return base.OnWindowStartingActionMode(callback);
        }

        public override ActionMode OnWindowStartingActionMode(ActionMode.ICallback callback, [GeneratedEnum] ActionModeType type)
        {
            return base.OnWindowStartingActionMode(callback, type);
        }

        public override Android.Support.V7.View.ActionMode OnWindowStartingSupportActionMode(Android.Support.V7.View.ActionMode.ICallback callback)
        {
            return base.OnWindowStartingSupportActionMode(callback);
        }

        public override void OpenContextMenu(View view)
        {
            base.OpenContextMenu(view);
        }

        public override Stream OpenFileInput(string name)
        {
            return base.OpenFileInput(name);
        }

        public override Stream OpenFileOutput(string name, [GeneratedEnum] FileCreationMode mode)
        {
            return base.OpenFileOutput(name, mode);
        }

        public override void OpenOptionsMenu()
        {
            base.OpenOptionsMenu();
        }

        public override SQLiteDatabase OpenOrCreateDatabase(string name, [GeneratedEnum] FileCreationMode mode, SQLiteDatabase.ICursorFactory factory)
        {
            return base.OpenOrCreateDatabase(name, mode, factory);
        }

        public override SQLiteDatabase OpenOrCreateDatabase(string name, [GeneratedEnum] FileCreationMode mode, SQLiteDatabase.ICursorFactory factory, IDatabaseErrorHandler errorHandler)
        {
            return base.OpenOrCreateDatabase(name, mode, factory, errorHandler);
        }

        public override void OverridePendingTransition(int enterAnim, int exitAnim)
        {
            base.OverridePendingTransition(enterAnim, exitAnim);
        }

        public override Drawable PeekWallpaper()
        {
            return base.PeekWallpaper();
        }

        public override void PostponeEnterTransition()
        {
            base.PostponeEnterTransition();
        }

        public override void Recreate()
        {
            base.Recreate();
        }

        public override void RegisterComponentCallbacks(IComponentCallbacks callback)
        {
            base.RegisterComponentCallbacks(callback);
        }

        public override void RegisterForContextMenu(View view)
        {
            base.RegisterForContextMenu(view);
        }

        public override Intent RegisterReceiver(BroadcastReceiver receiver, IntentFilter filter)
        {
            return base.RegisterReceiver(receiver, filter);
        }

        public override Intent RegisterReceiver(BroadcastReceiver receiver, IntentFilter filter, string broadcastPermission, Handler scheduler)
        {
            return base.RegisterReceiver(receiver, filter, broadcastPermission, scheduler);
        }

        public override bool ReleaseInstance()
        {
            return base.ReleaseInstance();
        }

        public override void RemoveStickyBroadcast(Intent intent)
        {
            base.RemoveStickyBroadcast(intent);
        }

        public override void RemoveStickyBroadcastAsUser(Intent intent, UserHandle user)
        {
            base.RemoveStickyBroadcastAsUser(intent, user);
        }

        public override void ReportFullyDrawn()
        {
            base.ReportFullyDrawn();
        }

        [Obsolete]
        public override bool RequestVisibleBehind(bool visible)
        {
            return base.RequestVisibleBehind(visible);
        }

        public override void RevokeUriPermission(Android.Net.Uri uri, [GeneratedEnum] ActivityFlags modeFlags)
        {
            base.RevokeUriPermission(uri, modeFlags);
        }

        public override void SendBroadcast(Intent intent)
        {
            base.SendBroadcast(intent);
        }

        public override void SendBroadcast(Intent intent, string receiverPermission)
        {
            base.SendBroadcast(intent, receiverPermission);
        }

        public override void SendBroadcastAsUser(Intent intent, UserHandle user)
        {
            base.SendBroadcastAsUser(intent, user);
        }

        public override void SendBroadcastAsUser(Intent intent, UserHandle user, string receiverPermission)
        {
            base.SendBroadcastAsUser(intent, user, receiverPermission);
        }

        public override void SendOrderedBroadcast(Intent intent, string receiverPermission)
        {
            base.SendOrderedBroadcast(intent, receiverPermission);
        }

        public override void SendOrderedBroadcast(Intent intent, string receiverPermission, BroadcastReceiver resultReceiver, Handler scheduler, [GeneratedEnum] Result initialCode, string initialData, Bundle initialExtras)
        {
            base.SendOrderedBroadcast(intent, receiverPermission, resultReceiver, scheduler, initialCode, initialData, initialExtras);
        }

        public override void SendOrderedBroadcastAsUser(Intent intent, UserHandle user, string receiverPermission, BroadcastReceiver resultReceiver, Handler scheduler, [GeneratedEnum] Result initialCode, string initialData, Bundle initialExtras)
        {
            base.SendOrderedBroadcastAsUser(intent, user, receiverPermission, resultReceiver, scheduler, initialCode, initialData, initialExtras);
        }

        public override void SendStickyBroadcast(Intent intent)
        {
            base.SendStickyBroadcast(intent);
        }

        public override void SendStickyBroadcastAsUser(Intent intent, UserHandle user)
        {
            base.SendStickyBroadcastAsUser(intent, user);
        }

        public override void SendStickyOrderedBroadcast(Intent intent, BroadcastReceiver resultReceiver, Handler scheduler, [GeneratedEnum] Result initialCode, string initialData, Bundle initialExtras)
        {
            base.SendStickyOrderedBroadcast(intent, resultReceiver, scheduler, initialCode, initialData, initialExtras);
        }

        public override void SendStickyOrderedBroadcastAsUser(Intent intent, UserHandle user, BroadcastReceiver resultReceiver, Handler scheduler, [GeneratedEnum] Result initialCode, string initialData, Bundle initialExtras)
        {
            base.SendStickyOrderedBroadcastAsUser(intent, user, resultReceiver, scheduler, initialCode, initialData, initialExtras);
        }

        public override void SetActionBar(Android.Widget.Toolbar toolbar)
        {
            base.SetActionBar(toolbar);
        }

        public override void SetContentView(View view)
        {
            base.SetContentView(view);
        }

        public override void SetContentView(View view, ViewGroup.LayoutParams @params)
        {
            base.SetContentView(view, @params);
        }

        public override void SetContentView(int layoutResID)
        {
            base.SetContentView(layoutResID);
        }

        public override void SetEnterSharedElementCallback(Android.App.SharedElementCallback callback)
        {
            base.SetEnterSharedElementCallback(callback);
        }

        public override void SetEnterSharedElementCallback(Android.Support.V4.App.SharedElementCallback callback)
        {
            base.SetEnterSharedElementCallback(callback);
        }

        public override void SetExitSharedElementCallback(Android.App.SharedElementCallback callback)
        {
            base.SetExitSharedElementCallback(callback);
        }

        public override void SetExitSharedElementCallback(Android.Support.V4.App.SharedElementCallback listener)
        {
            base.SetExitSharedElementCallback(listener);
        }

        public override void SetFinishOnTouchOutside(bool finish)
        {
            base.SetFinishOnTouchOutside(finish);
        }

        public override void SetPersistent(bool isPersistent)
        {
            base.SetPersistent(isPersistent);
        }

        public override void SetSupportActionBar(SupportToolbar toolbar)
        {
            base.SetSupportActionBar(toolbar);
        }

        [Obsolete]
        public override void SetSupportProgress(int progress)
        {
            base.SetSupportProgress(progress);
        }

        [Obsolete]
        public override void SetSupportProgressBarIndeterminate(bool indeterminate)
        {
            base.SetSupportProgressBarIndeterminate(indeterminate);
        }

        [Obsolete]
        public override void SetSupportProgressBarIndeterminateVisibility(bool visible)
        {
            base.SetSupportProgressBarIndeterminateVisibility(visible);
        }

        [Obsolete]
        public override void SetSupportProgressBarVisibility(bool visible)
        {
            base.SetSupportProgressBarVisibility(visible);
        }

        public override void SetTaskDescription(ActivityManager.TaskDescription taskDescription)
        {
            base.SetTaskDescription(taskDescription);
        }

        public override void SetTheme(int resid)
        {
            base.SetTheme(resid);
        }

        public override void SetTitle(int titleId)
        {
            base.SetTitle(titleId);
        }

        public override void SetVisible(bool visible)
        {
            base.SetVisible(visible);
        }

        public override void SetWallpaper(Bitmap bitmap)
        {
            base.SetWallpaper(bitmap);
        }

        public override void SetWallpaper(Stream data)
        {
            base.SetWallpaper(data);
        }

        public override bool ShouldShowRequestPermissionRationale(string permission)
        {
            return base.ShouldShowRequestPermissionRationale(permission);
        }

        public override bool ShouldUpRecreateTask(Intent targetIntent)
        {
            return base.ShouldUpRecreateTask(targetIntent);
        }

        public override bool ShowAssist(Bundle args)
        {
            return base.ShowAssist(args);
        }

        public override void ShowLockTaskEscapeMessage()
        {
            base.ShowLockTaskEscapeMessage();
        }

        public override Android.Views.ActionMode StartActionMode(Android.Views.ActionMode.ICallback callback)
        {
            return base.StartActionMode(callback);
        }

        public override Android.Views.ActionMode StartActionMode(Android.Views.ActionMode.ICallback callback, [GeneratedEnum] ActionModeType type)
        {
            return base.StartActionMode(callback, type);
        }

        public override void StartActivities(Intent[] intents)
        {
            base.StartActivities(intents);
        }

        public override void StartActivities(Intent[] intents, Bundle options)
        {
            base.StartActivities(intents, options);
        }

        public override void StartActivity(Intent intent)
        {
            base.StartActivity(intent);
        }

        public override void StartActivity(Intent intent, Bundle options)
        {
            base.StartActivity(intent, options);
        }

        public override void StartActivityForResult(Intent intent, int requestCode)
        {
            base.StartActivityForResult(intent, requestCode);
        }

        public override void StartActivityForResult(Intent intent, int requestCode, Bundle options)
        {
            base.StartActivityForResult(intent, requestCode, options);
        }

        public override void StartActivityFromChild(Activity child, Intent intent, int requestCode)
        {
            base.StartActivityFromChild(child, intent, requestCode);
        }

        public override void StartActivityFromChild(Activity child, Intent intent, int requestCode, Bundle options)
        {
            base.StartActivityFromChild(child, intent, requestCode, options);
        }

        public override void StartActivityFromFragment(Android.App.Fragment fragment, Intent intent, int requestCode)
        {
            base.StartActivityFromFragment(fragment, intent, requestCode);
        }

        public override void StartActivityFromFragment(Android.App.Fragment fragment, Intent intent, int requestCode, Bundle options)
        {
            base.StartActivityFromFragment(fragment, intent, requestCode, options);
        }

        public override void StartActivityFromFragment(Android.Support.V4.App.Fragment fragment, Intent intent, int requestCode)
        {
            base.StartActivityFromFragment(fragment, intent, requestCode);
        }

        public override void StartActivityFromFragment(Android.Support.V4.App.Fragment fragment, Intent intent, int requestCode, Bundle options)
        {
            base.StartActivityFromFragment(fragment, intent, requestCode, options);
        }

        public override bool StartActivityIfNeeded(Intent intent, int requestCode)
        {
            return base.StartActivityIfNeeded(intent, requestCode);
        }

        public override bool StartActivityIfNeeded(Intent intent, int requestCode, Bundle options)
        {
            return base.StartActivityIfNeeded(intent, requestCode, options);
        }

        public override bool StartInstrumentation(ComponentName className, string profileFile, Bundle arguments)
        {
            return base.StartInstrumentation(className, profileFile, arguments);
        }

        public override void StartIntentSender(IntentSender intent, Intent fillInIntent, [GeneratedEnum] ActivityFlags flagsMask, [GeneratedEnum] ActivityFlags flagsValues, int extraFlags)
        {
            base.StartIntentSender(intent, fillInIntent, flagsMask, flagsValues, extraFlags);
        }

        public override void StartIntentSender(IntentSender intent, Intent fillInIntent, [GeneratedEnum] ActivityFlags flagsMask, [GeneratedEnum] ActivityFlags flagsValues, int extraFlags, Bundle options)
        {
            base.StartIntentSender(intent, fillInIntent, flagsMask, flagsValues, extraFlags, options);
        }

        public override void StartIntentSenderForResult(IntentSender intent, int requestCode, Intent fillInIntent, [GeneratedEnum] ActivityFlags flagsMask, [GeneratedEnum] ActivityFlags flagsValues, int extraFlags)
        {
            base.StartIntentSenderForResult(intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags);
        }

        public override void StartIntentSenderForResult(IntentSender intent, int requestCode, Intent fillInIntent, [GeneratedEnum] ActivityFlags flagsMask, [GeneratedEnum] ActivityFlags flagsValues, int extraFlags, Bundle options)
        {
            base.StartIntentSenderForResult(intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags, options);
        }

        public override void StartIntentSenderFromChild(Activity child, IntentSender intent, int requestCode, Intent fillInIntent, [GeneratedEnum] ActivityFlags flagsMask, [GeneratedEnum] ActivityFlags flagsValues, int extraFlags)
        {
            base.StartIntentSenderFromChild(child, intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags);
        }

        public override void StartIntentSenderFromChild(Activity child, IntentSender intent, int requestCode, Intent fillInIntent, [GeneratedEnum] ActivityFlags flagsMask, [GeneratedEnum] ActivityFlags flagsValues, int extraFlags, Bundle options)
        {
            base.StartIntentSenderFromChild(child, intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags, options);
        }

        public override void StartIntentSenderFromFragment(Android.Support.V4.App.Fragment fragment, IntentSender intent, int requestCode, Intent fillInIntent, int flagsMask, int flagsValues, int extraFlags, Bundle options)
        {
            base.StartIntentSenderFromFragment(fragment, intent, requestCode, fillInIntent, flagsMask, flagsValues, extraFlags, options);
        }

        public override void StartLockTask()
        {
            base.StartLockTask();
        }

        [Obsolete]
        public override void StartManagingCursor(ICursor c)
        {
            base.StartManagingCursor(c);
        }

        public override bool StartNextMatchingActivity(Intent intent)
        {
            return base.StartNextMatchingActivity(intent);
        }

        public override bool StartNextMatchingActivity(Intent intent, Bundle options)
        {
            return base.StartNextMatchingActivity(intent, options);
        }

        public override void StartPostponedEnterTransition()
        {
            base.StartPostponedEnterTransition();
        }

        public override void StartSearch(string initialQuery, bool selectInitialQuery, Bundle appSearchData, bool globalSearch)
        {
            base.StartSearch(initialQuery, selectInitialQuery, appSearchData, globalSearch);
        }

        public override ComponentName StartService(Intent service)
        {
            return base.StartService(service);
        }

        public override Android.Support.V7.View.ActionMode StartSupportActionMode(Android.Support.V7.View.ActionMode.ICallback callback)
        {
            return base.StartSupportActionMode(callback);
        }

        public override void StopLockTask()
        {
            base.StopLockTask();
        }

        [Obsolete]
        public override void StopManagingCursor(ICursor c)
        {
            base.StopManagingCursor(c);
        }

        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }

        public override void SupportFinishAfterTransition()
        {
            base.SupportFinishAfterTransition();
        }

        [Obsolete]
        public override void SupportInvalidateOptionsMenu()
        {
            base.SupportInvalidateOptionsMenu();
        }

        public override void SupportNavigateUpTo(Intent upIntent)
        {
            base.SupportNavigateUpTo(upIntent);
        }

        public override void SupportPostponeEnterTransition()
        {
            base.SupportPostponeEnterTransition();
        }

        public override bool SupportRequestWindowFeature(int featureId)
        {
            return base.SupportRequestWindowFeature(featureId);
        }

        public override bool SupportShouldUpRecreateTask(Intent targetIntent)
        {
            return base.SupportShouldUpRecreateTask(targetIntent);
        }

        public override void SupportStartPostponedEnterTransition()
        {
            base.SupportStartPostponedEnterTransition();
        }

        public override void TakeKeyEvents(bool get)
        {
            base.TakeKeyEvents(get);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void TriggerSearch(string query, Bundle appSearchData)
        {
            base.TriggerSearch(query, appSearchData);
        }

        public override void UnbindService(IServiceConnection conn)
        {
            base.UnbindService(conn);
        }

        public override void UnregisterComponentCallbacks(IComponentCallbacks callback)
        {
            base.UnregisterComponentCallbacks(callback);
        }

        public override void UnregisterForContextMenu(View view)
        {
            base.UnregisterForContextMenu(view);
        }

        public override void UnregisterReceiver(BroadcastReceiver receiver)
        {
            base.UnregisterReceiver(receiver);
        }

        protected override void AttachBaseContext(Context @base)
        {
            base.AttachBaseContext(@base);
        }

        protected override Java.Lang.Object Clone()
        {
            return base.Clone();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void JavaFinalize()
        {
            base.JavaFinalize();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnApplyThemeResource(Resources.Theme theme, int resid, bool first)
        {
            base.OnApplyThemeResource(theme, resid, first);
        }

        protected override void OnChildTitleChanged(Activity childActivity, ICharSequence title)
        {
            base.OnChildTitleChanged(childActivity, title);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        [Obsolete]
        protected override Dialog OnCreateDialog(int id)
        {
            return base.OnCreateDialog(id);
        }

        [Obsolete]
        protected override Dialog OnCreateDialog(int id, Bundle args)
        {
            return base.OnCreateDialog(id, args);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
        }

        protected override void OnPostResume()
        {
            base.OnPostResume();
        }

        [Obsolete]
        protected override void OnPrepareDialog(int id, Dialog dialog)
        {
            base.OnPrepareDialog(id, dialog);
        }

        [Obsolete]
        protected override void OnPrepareDialog(int id, Dialog dialog, Bundle args)
        {
            base.OnPrepareDialog(id, dialog, args);
        }

        protected override bool OnPrepareOptionsPanel(View view, IMenu menu)
        {
            return base.OnPrepareOptionsPanel(view, menu);
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnResumeFragments()
        {
            base.OnResumeFragments();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        protected override void OnStart()
        {
            base.OnStart();

            this.InitiateToolbarAndDrawer();
        }
        
        protected override void OnStop()
        {
            base.OnStop();
        }

        protected override void OnTitleChanged(ICharSequence title, [GeneratedEnum] Color color)
        {
            base.OnTitleChanged(title, color);
        }

        protected override void OnUserLeaveHint()
        {
            base.OnUserLeaveHint();
        }

        protected void InitiateToolbarAndDrawer()
        {
            var toolbar = this.FindViewById<SupportToolbar>(Resource.Id.toolBar);

            if (toolbar != null)
            {
                this.SetSupportActionBar(toolbar);

                var actionBar = this.SupportActionBar;

                actionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
                actionBar.SetDisplayHomeAsUpEnabled(true);
                actionBar.SetLogo(Resource.Drawable.logohd);
                actionBar.SetDisplayShowTitleEnabled(false);

                this.drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

                this.navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

                navigationView.NavigationItemSelected -= OnNavigationViewNavigationItemSelected;

                if (navigationView != null)
                {
                    this.SetUpDrawerContent(navigationView);
                }
            }
        }

        protected void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += OnNavigationViewNavigationItemSelected;
        }

        private void OnNavigationViewNavigationItemSelected(object sender,
            NavigationView.NavigationItemSelectedEventArgs args)
        {
            if (args.MenuItem.ItemId != Resource.Id.contactUs)
            {
                if (args.MenuItem.ItemId == Resource.Id.logout)
                {
                    this.Logout();
                }
                else
                {
                    this.OpenLegalNotesFragment(args.MenuItem);

                    drawerLayout.CloseDrawers();
                }
            }
            else
            {
                var email = new Intent(Intent.ActionSend);

                email.PutExtra(Intent.ExtraEmail,
                               new string[] { "e-info@asawer.com" });

                email.SetType("message/rfc822");
                StartActivity(email);
            }
        }

        protected abstract void Logout();

        protected void OpenLegalNotesFragment(IMenuItem item)
        {
            Bundle mybundle = new Bundle();

            mybundle.PutInt("ItemId", item.ItemId);

            var transaction = SupportFragmentManager.BeginTransaction();

            var legalNotesFragment = new LegalNotesFragment
            {
                Arguments = mybundle
            };

            legalNotesFragment.Show(transaction, "dialog_fragment");

            item.SetChecked(false);
        }
    }
}