package md5e7d32db6922e6c124d8d5fc4898d1e91;


public abstract class AsawerAppCompatActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isRestricted:()Z:GetIsRestrictedHandler\n" +
			"n_getApplicationContext:()Landroid/content/Context;:GetGetApplicationContextHandler\n" +
			"n_getApplicationInfo:()Landroid/content/pm/ApplicationInfo;:GetGetApplicationInfoHandler\n" +
			"n_getAssets:()Landroid/content/res/AssetManager;:GetGetAssetsHandler\n" +
			"n_getBaseContext:()Landroid/content/Context;:GetGetBaseContextHandler\n" +
			"n_getCacheDir:()Ljava/io/File;:GetGetCacheDirHandler\n" +
			"n_getClassLoader:()Ljava/lang/ClassLoader;:GetGetClassLoaderHandler\n" +
			"n_getCodeCacheDir:()Ljava/io/File;:GetGetCodeCacheDirHandler\n" +
			"n_getContentResolver:()Landroid/content/ContentResolver;:GetGetContentResolverHandler\n" +
			"n_getExternalCacheDir:()Ljava/io/File;:GetGetExternalCacheDirHandler\n" +
			"n_getFilesDir:()Ljava/io/File;:GetGetFilesDirHandler\n" +
			"n_getMainLooper:()Landroid/os/Looper;:GetGetMainLooperHandler\n" +
			"n_getNoBackupFilesDir:()Ljava/io/File;:GetGetNoBackupFilesDirHandler\n" +
			"n_getObbDir:()Ljava/io/File;:GetGetObbDirHandler\n" +
			"n_getPackageCodePath:()Ljava/lang/String;:GetGetPackageCodePathHandler\n" +
			"n_getPackageManager:()Landroid/content/pm/PackageManager;:GetGetPackageManagerHandler\n" +
			"n_getPackageName:()Ljava/lang/String;:GetGetPackageNameHandler\n" +
			"n_getPackageResourcePath:()Ljava/lang/String;:GetGetPackageResourcePathHandler\n" +
			"n_getTheme:()Landroid/content/res/Resources$Theme;:GetGetThemeHandler\n" +
			"n_getWallpaper:()Landroid/graphics/drawable/Drawable;:GetGetWallpaperHandler\n" +
			"n_getWallpaperDesiredMinimumHeight:()I:GetGetWallpaperDesiredMinimumHeightHandler\n" +
			"n_getWallpaperDesiredMinimumWidth:()I:GetGetWallpaperDesiredMinimumWidthHandler\n" +
			"n_getActionBar:()Landroid/app/ActionBar;:GetGetActionBarHandler\n" +
			"n_getCallingActivity:()Landroid/content/ComponentName;:GetGetCallingActivityHandler\n" +
			"n_getCallingPackage:()Ljava/lang/String;:GetGetCallingPackageHandler\n" +
			"n_getChangingConfigurations:()I:GetGetChangingConfigurationsHandler\n" +
			"n_getComponentName:()Landroid/content/ComponentName;:GetGetComponentNameHandler\n" +
			"n_getContentScene:()Landroid/transition/Scene;:GetGetContentSceneHandler\n" +
			"n_getContentTransitionManager:()Landroid/transition/TransitionManager;:GetGetContentTransitionManagerHandler\n" +
			"n_setContentTransitionManager:(Landroid/transition/TransitionManager;)V:GetSetContentTransitionManager_Landroid_transition_TransitionManager_Handler\n" +
			"n_getCurrentFocus:()Landroid/view/View;:GetGetCurrentFocusHandler\n" +
			"n_getFragmentManager:()Landroid/app/FragmentManager;:GetGetFragmentManagerHandler\n" +
			"n_hasWindowFocus:()Z:GetHasWindowFocusHandler\n" +
			"n_isImmersive:()Z:GetIsImmersiveHandler\n" +
			"n_setImmersive:(Z)V:GetSetImmersive_ZHandler\n" +
			"n_getIntent:()Landroid/content/Intent;:GetGetIntentHandler\n" +
			"n_setIntent:(Landroid/content/Intent;)V:GetSetIntent_Landroid_content_Intent_Handler\n" +
			"n_isChangingConfigurations:()Z:GetIsChangingConfigurationsHandler\n" +
			"n_isDestroyed:()Z:GetIsDestroyedHandler\n" +
			"n_isFinishing:()Z:GetIsFinishingHandler\n" +
			"n_isTaskRoot:()Z:GetIsTaskRootHandler\n" +
			"n_isVoiceInteraction:()Z:GetIsVoiceInteractionHandler\n" +
			"n_isVoiceInteractionRoot:()Z:GetIsVoiceInteractionRootHandler\n" +
			"n_getLastNonConfigurationInstance:()Ljava/lang/Object;:GetGetLastNonConfigurationInstanceHandler\n" +
			"n_getLayoutInflater:()Landroid/view/LayoutInflater;:GetGetLayoutInflaterHandler\n" +
			"n_getLoaderManager:()Landroid/app/LoaderManager;:GetGetLoaderManagerHandler\n" +
			"n_getLocalClassName:()Ljava/lang/String;:GetGetLocalClassNameHandler\n" +
			"n_getParentActivityIntent:()Landroid/content/Intent;:GetGetParentActivityIntentHandler\n" +
			"n_getReferrer:()Landroid/net/Uri;:GetGetReferrerHandler\n" +
			"n_getRequestedOrientation:()I:GetGetRequestedOrientationHandler\n" +
			"n_setRequestedOrientation:(I)V:GetSetRequestedOrientation_IHandler\n" +
			"n_getTaskId:()I:GetGetTaskIdHandler\n" +
			"n_getVoiceInteractor:()Landroid/app/VoiceInteractor;:GetGetVoiceInteractorHandler\n" +
			"n_getWindow:()Landroid/view/Window;:GetGetWindowHandler\n" +
			"n_getWindowManager:()Landroid/view/WindowManager;:GetGetWindowManagerHandler\n" +
			"n_getLastCustomNonConfigurationInstance:()Ljava/lang/Object;:GetGetLastCustomNonConfigurationInstanceHandler\n" +
			"n_getSupportFragmentManager:()Landroid/support/v4/app/FragmentManager;:GetGetSupportFragmentManagerHandler\n" +
			"n_getSupportLoaderManager:()Landroid/support/v4/app/LoaderManager;:GetGetSupportLoaderManagerHandler\n" +
			"n_getDelegate:()Landroid/support/v7/app/AppCompatDelegate;:GetGetDelegateHandler\n" +
			"n_getDrawerToggleDelegate:()Landroid/support/v7/app/ActionBarDrawerToggle$Delegate;:GetGetDrawerToggleDelegateHandler\n" +
			"n_getMenuInflater:()Landroid/view/MenuInflater;:GetGetMenuInflaterHandler\n" +
			"n_getResources:()Landroid/content/res/Resources;:GetGetResourcesHandler\n" +
			"n_getSupportActionBar:()Landroid/support/v7/app/ActionBar;:GetGetSupportActionBarHandler\n" +
			"n_getSupportParentActivityIntent:()Landroid/content/Intent;:GetGetSupportParentActivityIntentHandler\n" +
			"n_addContentView:(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V:GetAddContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler\n" +
			"n_applyOverrideConfiguration:(Landroid/content/res/Configuration;)V:GetApplyOverrideConfiguration_Landroid_content_res_Configuration_Handler\n" +
			"n_bindService:(Landroid/content/Intent;Landroid/content/ServiceConnection;I)Z:GetBindService_Landroid_content_Intent_Landroid_content_ServiceConnection_IHandler\n" +
			"n_checkCallingOrSelfPermission:(Ljava/lang/String;)I:GetCheckCallingOrSelfPermission_Ljava_lang_String_Handler\n" +
			"n_checkCallingOrSelfUriPermission:(Landroid/net/Uri;I)I:GetCheckCallingOrSelfUriPermission_Landroid_net_Uri_IHandler\n" +
			"n_checkCallingPermission:(Ljava/lang/String;)I:GetCheckCallingPermission_Ljava_lang_String_Handler\n" +
			"n_checkCallingUriPermission:(Landroid/net/Uri;I)I:GetCheckCallingUriPermission_Landroid_net_Uri_IHandler\n" +
			"n_checkPermission:(Ljava/lang/String;II)I:GetCheckPermission_Ljava_lang_String_IIHandler\n" +
			"n_checkSelfPermission:(Ljava/lang/String;)I:GetCheckSelfPermission_Ljava_lang_String_Handler\n" +
			"n_checkUriPermission:(Landroid/net/Uri;III)I:GetCheckUriPermission_Landroid_net_Uri_IIIHandler\n" +
			"n_checkUriPermission:(Landroid/net/Uri;Ljava/lang/String;Ljava/lang/String;III)I:GetCheckUriPermission_Landroid_net_Uri_Ljava_lang_String_Ljava_lang_String_IIIHandler\n" +
			"n_clearWallpaper:()V:GetClearWallpaperHandler\n" +
			"n_closeContextMenu:()V:GetCloseContextMenuHandler\n" +
			"n_closeOptionsMenu:()V:GetCloseOptionsMenuHandler\n" +
			"n_createConfigurationContext:(Landroid/content/res/Configuration;)Landroid/content/Context;:GetCreateConfigurationContext_Landroid_content_res_Configuration_Handler\n" +
			"n_createDisplayContext:(Landroid/view/Display;)Landroid/content/Context;:GetCreateDisplayContext_Landroid_view_Display_Handler\n" +
			"n_createPackageContext:(Ljava/lang/String;I)Landroid/content/Context;:GetCreatePackageContext_Ljava_lang_String_IHandler\n" +
			"n_createPendingResult:(ILandroid/content/Intent;I)Landroid/app/PendingIntent;:GetCreatePendingResult_ILandroid_content_Intent_IHandler\n" +
			"n_databaseList:()[Ljava/lang/String;:GetDatabaseListHandler\n" +
			"n_deleteDatabase:(Ljava/lang/String;)Z:GetDeleteDatabase_Ljava_lang_String_Handler\n" +
			"n_deleteFile:(Ljava/lang/String;)Z:GetDeleteFile_Ljava_lang_String_Handler\n" +
			"n_dispatchGenericMotionEvent:(Landroid/view/MotionEvent;)Z:GetDispatchGenericMotionEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_dispatchKeyEvent:(Landroid/view/KeyEvent;)Z:GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler\n" +
			"n_dispatchKeyShortcutEvent:(Landroid/view/KeyEvent;)Z:GetDispatchKeyShortcutEvent_Landroid_view_KeyEvent_Handler\n" +
			"n_dispatchPopulateAccessibilityEvent:(Landroid/view/accessibility/AccessibilityEvent;)Z:GetDispatchPopulateAccessibilityEvent_Landroid_view_accessibility_AccessibilityEvent_Handler\n" +
			"n_dispatchTouchEvent:(Landroid/view/MotionEvent;)Z:GetDispatchTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_dispatchTrackballEvent:(Landroid/view/MotionEvent;)Z:GetDispatchTrackballEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_dump:(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V:GetDump_Ljava_lang_String_Ljava_io_FileDescriptor_Ljava_io_PrintWriter_arrayLjava_lang_String_Handler\n" +
			"n_enforceCallingOrSelfPermission:(Ljava/lang/String;Ljava/lang/String;)V:GetEnforceCallingOrSelfPermission_Ljava_lang_String_Ljava_lang_String_Handler\n" +
			"n_enforceCallingOrSelfUriPermission:(Landroid/net/Uri;ILjava/lang/String;)V:GetEnforceCallingOrSelfUriPermission_Landroid_net_Uri_ILjava_lang_String_Handler\n" +
			"n_enforceCallingPermission:(Ljava/lang/String;Ljava/lang/String;)V:GetEnforceCallingPermission_Ljava_lang_String_Ljava_lang_String_Handler\n" +
			"n_enforceCallingUriPermission:(Landroid/net/Uri;ILjava/lang/String;)V:GetEnforceCallingUriPermission_Landroid_net_Uri_ILjava_lang_String_Handler\n" +
			"n_enforcePermission:(Ljava/lang/String;IILjava/lang/String;)V:GetEnforcePermission_Ljava_lang_String_IILjava_lang_String_Handler\n" +
			"n_enforceUriPermission:(Landroid/net/Uri;IIILjava/lang/String;)V:GetEnforceUriPermission_Landroid_net_Uri_IIILjava_lang_String_Handler\n" +
			"n_enforceUriPermission:(Landroid/net/Uri;Ljava/lang/String;Ljava/lang/String;IIILjava/lang/String;)V:GetEnforceUriPermission_Landroid_net_Uri_Ljava_lang_String_Ljava_lang_String_IIILjava_lang_String_Handler\n" +
			"n_equals:(Ljava/lang/Object;)Z:GetEquals_Ljava_lang_Object_Handler\n" +
			"n_fileList:()[Ljava/lang/String;:GetFileListHandler\n" +
			"n_findViewById:(I)Landroid/view/View;:GetFindViewById_IHandler\n" +
			"n_finish:()V:GetFinishHandler\n" +
			"n_finishActivity:(I)V:GetFinishActivity_IHandler\n" +
			"n_finishActivityFromChild:(Landroid/app/Activity;I)V:GetFinishActivityFromChild_Landroid_app_Activity_IHandler\n" +
			"n_finishAffinity:()V:GetFinishAffinityHandler\n" +
			"n_finishAfterTransition:()V:GetFinishAfterTransitionHandler\n" +
			"n_finishAndRemoveTask:()V:GetFinishAndRemoveTaskHandler\n" +
			"n_finishFromChild:(Landroid/app/Activity;)V:GetFinishFromChild_Landroid_app_Activity_Handler\n" +
			"n_getDatabasePath:(Ljava/lang/String;)Ljava/io/File;:GetGetDatabasePath_Ljava_lang_String_Handler\n" +
			"n_getDir:(Ljava/lang/String;I)Ljava/io/File;:GetGetDir_Ljava_lang_String_IHandler\n" +
			"n_getExternalCacheDirs:()[Ljava/io/File;:GetGetExternalCacheDirsHandler\n" +
			"n_getExternalFilesDir:(Ljava/lang/String;)Ljava/io/File;:GetGetExternalFilesDir_Ljava_lang_String_Handler\n" +
			"n_getExternalFilesDirs:(Ljava/lang/String;)[Ljava/io/File;:GetGetExternalFilesDirs_Ljava_lang_String_Handler\n" +
			"n_getExternalMediaDirs:()[Ljava/io/File;:GetGetExternalMediaDirsHandler\n" +
			"n_getFileStreamPath:(Ljava/lang/String;)Ljava/io/File;:GetGetFileStreamPath_Ljava_lang_String_Handler\n" +
			"n_hashCode:()I:GetGetHashCodeHandler\n" +
			"n_getObbDirs:()[Ljava/io/File;:GetGetObbDirsHandler\n" +
			"n_getPreferences:(I)Landroid/content/SharedPreferences;:GetGetPreferences_IHandler\n" +
			"n_getSharedPreferences:(Ljava/lang/String;I)Landroid/content/SharedPreferences;:GetGetSharedPreferences_Ljava_lang_String_IHandler\n" +
			"n_getSystemService:(Ljava/lang/String;)Ljava/lang/Object;:GetGetSystemService_Ljava_lang_String_Handler\n" +
			"n_getSystemServiceName:(Ljava/lang/Class;)Ljava/lang/String;:GetGetSystemServiceName_Ljava_lang_Class_Handler\n" +
			"n_grantUriPermission:(Ljava/lang/String;Landroid/net/Uri;I)V:GetGrantUriPermission_Ljava_lang_String_Landroid_net_Uri_IHandler\n" +
			"n_invalidateOptionsMenu:()V:GetInvalidateOptionsMenuHandler\n" +
			"n_moveTaskToBack:(Z)Z:GetMoveTaskToBack_ZHandler\n" +
			"n_navigateUpTo:(Landroid/content/Intent;)Z:GetNavigateUpTo_Landroid_content_Intent_Handler\n" +
			"n_navigateUpToFromChild:(Landroid/app/Activity;Landroid/content/Intent;)Z:GetNavigateUpToFromChild_Landroid_app_Activity_Landroid_content_Intent_Handler\n" +
			"n_onActionModeFinished:(Landroid/view/ActionMode;)V:GetOnActionModeFinished_Landroid_view_ActionMode_Handler\n" +
			"n_onActionModeStarted:(Landroid/view/ActionMode;)V:GetOnActionModeStarted_Landroid_view_ActionMode_Handler\n" +
			"n_onActivityReenter:(ILandroid/content/Intent;)V:GetOnActivityReenter_ILandroid_content_Intent_Handler\n" +
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onAttachFragment:(Landroid/app/Fragment;)V:GetOnAttachFragment_Landroid_app_Fragment_Handler\n" +
			"n_onAttachFragment:(Landroid/support/v4/app/Fragment;)V:GetOnAttachFragment_Landroid_support_v4_app_Fragment_Handler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"n_onConfigurationChanged:(Landroid/content/res/Configuration;)V:GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler\n" +
			"n_onContentChanged:()V:GetOnContentChangedHandler\n" +
			"n_onContextItemSelected:(Landroid/view/MenuItem;)Z:GetOnContextItemSelected_Landroid_view_MenuItem_Handler\n" +
			"n_onContextMenuClosed:(Landroid/view/Menu;)V:GetOnContextMenuClosed_Landroid_view_Menu_Handler\n" +
			"n_onCreate:(Landroid/os/Bundle;Landroid/os/PersistableBundle;)V:GetOnCreate_Landroid_os_Bundle_Landroid_os_PersistableBundle_Handler\n" +
			"n_onCreateContextMenu:(Landroid/view/ContextMenu;Landroid/view/View;Landroid/view/ContextMenu$ContextMenuInfo;)V:GetOnCreateContextMenu_Landroid_view_ContextMenu_Landroid_view_View_Landroid_view_ContextMenu_ContextMenuInfo_Handler\n" +
			"n_onCreateDescription:()Ljava/lang/CharSequence;:GetOnCreateDescriptionHandler\n" +
			"n_onCreateNavigateUpTaskStack:(Landroid/app/TaskStackBuilder;)V:GetOnCreateNavigateUpTaskStack_Landroid_app_TaskStackBuilder_Handler\n" +
			"n_onCreateOptionsMenu:(Landroid/view/Menu;)Z:GetOnCreateOptionsMenu_Landroid_view_Menu_Handler\n" +
			"n_onCreatePanelMenu:(ILandroid/view/Menu;)Z:GetOnCreatePanelMenu_ILandroid_view_Menu_Handler\n" +
			"n_onCreatePanelView:(I)Landroid/view/View;:GetOnCreatePanelView_IHandler\n" +
			"n_onCreateSupportNavigateUpTaskStack:(Landroid/support/v4/app/TaskStackBuilder;)V:GetOnCreateSupportNavigateUpTaskStack_Landroid_support_v4_app_TaskStackBuilder_Handler\n" +
			"n_onCreateThumbnail:(Landroid/graphics/Bitmap;Landroid/graphics/Canvas;)Z:GetOnCreateThumbnail_Landroid_graphics_Bitmap_Landroid_graphics_Canvas_Handler\n" +
			"n_onCreateView:(Landroid/view/View;Ljava/lang/String;Landroid/content/Context;Landroid/util/AttributeSet;)Landroid/view/View;:GetOnCreateView_Landroid_view_View_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet_Handler\n" +
			"n_onCreateView:(Ljava/lang/String;Landroid/content/Context;Landroid/util/AttributeSet;)Landroid/view/View;:GetOnCreateView_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet_Handler\n" +
			"n_onDetachedFromWindow:()V:GetOnDetachedFromWindowHandler\n" +
			"n_onEnterAnimationComplete:()V:GetOnEnterAnimationCompleteHandler\n" +
			"n_onGenericMotionEvent:(Landroid/view/MotionEvent;)Z:GetOnGenericMotionEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onKeyDown:(ILandroid/view/KeyEvent;)Z:GetOnKeyDown_ILandroid_view_KeyEvent_Handler\n" +
			"n_onKeyLongPress:(ILandroid/view/KeyEvent;)Z:GetOnKeyLongPress_ILandroid_view_KeyEvent_Handler\n" +
			"n_onKeyMultiple:(IILandroid/view/KeyEvent;)Z:GetOnKeyMultiple_IILandroid_view_KeyEvent_Handler\n" +
			"n_onKeyShortcut:(ILandroid/view/KeyEvent;)Z:GetOnKeyShortcut_ILandroid_view_KeyEvent_Handler\n" +
			"n_onKeyUp:(ILandroid/view/KeyEvent;)Z:GetOnKeyUp_ILandroid_view_KeyEvent_Handler\n" +
			"n_onLowMemory:()V:GetOnLowMemoryHandler\n" +
			"n_onMenuOpened:(ILandroid/view/Menu;)Z:GetOnMenuOpened_ILandroid_view_Menu_Handler\n" +
			"n_onMultiWindowModeChanged:(Z)V:GetOnMultiWindowModeChanged_ZHandler\n" +
			"n_onNavigateUp:()Z:GetOnNavigateUpHandler\n" +
			"n_onNavigateUpFromChild:(Landroid/app/Activity;)Z:GetOnNavigateUpFromChild_Landroid_app_Activity_Handler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"n_onOptionsMenuClosed:(Landroid/view/Menu;)V:GetOnOptionsMenuClosed_Landroid_view_Menu_Handler\n" +
			"n_onPanelClosed:(ILandroid/view/Menu;)V:GetOnPanelClosed_ILandroid_view_Menu_Handler\n" +
			"n_onPictureInPictureModeChanged:(Z)V:GetOnPictureInPictureModeChanged_ZHandler\n" +
			"n_onPostCreate:(Landroid/os/Bundle;Landroid/os/PersistableBundle;)V:GetOnPostCreate_Landroid_os_Bundle_Landroid_os_PersistableBundle_Handler\n" +
			"n_onPrepareNavigateUpTaskStack:(Landroid/app/TaskStackBuilder;)V:GetOnPrepareNavigateUpTaskStack_Landroid_app_TaskStackBuilder_Handler\n" +
			"n_onPrepareOptionsMenu:(Landroid/view/Menu;)Z:GetOnPrepareOptionsMenu_Landroid_view_Menu_Handler\n" +
			"n_onPreparePanel:(ILandroid/view/View;Landroid/view/Menu;)Z:GetOnPreparePanel_ILandroid_view_View_Landroid_view_Menu_Handler\n" +
			"n_onPrepareSupportNavigateUpTaskStack:(Landroid/support/v4/app/TaskStackBuilder;)V:GetOnPrepareSupportNavigateUpTaskStack_Landroid_support_v4_app_TaskStackBuilder_Handler\n" +
			"n_onProvideAssistContent:(Landroid/app/assist/AssistContent;)V:GetOnProvideAssistContent_Landroid_app_assist_AssistContent_Handler\n" +
			"n_onProvideAssistData:(Landroid/os/Bundle;)V:GetOnProvideAssistData_Landroid_os_Bundle_Handler\n" +
			"n_onProvideReferrer:()Landroid/net/Uri;:GetOnProvideReferrerHandler\n" +
			"n_onRequestPermissionsResult:(I[Ljava/lang/String;[I)V:GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler\n" +
			"n_onRestoreInstanceState:(Landroid/os/Bundle;Landroid/os/PersistableBundle;)V:GetOnRestoreInstanceState_Landroid_os_Bundle_Landroid_os_PersistableBundle_Handler\n" +
			"n_onRetainCustomNonConfigurationInstance:()Ljava/lang/Object;:GetOnRetainCustomNonConfigurationInstanceHandler\n" +
			"n_onSaveInstanceState:(Landroid/os/Bundle;Landroid/os/PersistableBundle;)V:GetOnSaveInstanceState_Landroid_os_Bundle_Landroid_os_PersistableBundle_Handler\n" +
			"n_onSearchRequested:()Z:GetOnSearchRequestedHandler\n" +
			"n_onSearchRequested:(Landroid/view/SearchEvent;)Z:GetOnSearchRequested_Landroid_view_SearchEvent_Handler\n" +
			"n_onStateNotSaved:()V:GetOnStateNotSavedHandler\n" +
			"n_onSupportActionModeFinished:(Landroid/support/v7/view/ActionMode;)V:GetOnSupportActionModeFinished_Landroid_support_v7_view_ActionMode_Handler\n" +
			"n_onSupportActionModeStarted:(Landroid/support/v7/view/ActionMode;)V:GetOnSupportActionModeStarted_Landroid_support_v7_view_ActionMode_Handler\n" +
			"n_onSupportContentChanged:()V:GetOnSupportContentChangedHandler\n" +
			"n_onSupportNavigateUp:()Z:GetOnSupportNavigateUpHandler\n" +
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onTrackballEvent:(Landroid/view/MotionEvent;)Z:GetOnTrackballEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onTrimMemory:(I)V:GetOnTrimMemory_IHandler\n" +
			"n_onUserInteraction:()V:GetOnUserInteractionHandler\n" +
			"n_onVisibleBehindCanceled:()V:GetOnVisibleBehindCanceledHandler\n" +
			"n_onWindowAttributesChanged:(Landroid/view/WindowManager$LayoutParams;)V:GetOnWindowAttributesChanged_Landroid_view_WindowManager_LayoutParams_Handler\n" +
			"n_onWindowFocusChanged:(Z)V:GetOnWindowFocusChanged_ZHandler\n" +
			"n_onWindowStartingActionMode:(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;:GetOnWindowStartingActionMode_Landroid_view_ActionMode_Callback_Handler\n" +
			"n_onWindowStartingActionMode:(Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;:GetOnWindowStartingActionMode_Landroid_view_ActionMode_Callback_IHandler\n" +
			"n_onWindowStartingSupportActionMode:(Landroid/support/v7/view/ActionMode$Callback;)Landroid/support/v7/view/ActionMode;:GetOnWindowStartingSupportActionMode_Landroid_support_v7_view_ActionMode_Callback_Handler\n" +
			"n_openContextMenu:(Landroid/view/View;)V:GetOpenContextMenu_Landroid_view_View_Handler\n" +
			"n_openFileInput:(Ljava/lang/String;)Ljava/io/FileInputStream;:GetOpenFileInput_Ljava_lang_String_Handler\n" +
			"n_openFileOutput:(Ljava/lang/String;I)Ljava/io/FileOutputStream;:GetOpenFileOutput_Ljava_lang_String_IHandler\n" +
			"n_openOptionsMenu:()V:GetOpenOptionsMenuHandler\n" +
			"n_openOrCreateDatabase:(Ljava/lang/String;ILandroid/database/sqlite/SQLiteDatabase$CursorFactory;)Landroid/database/sqlite/SQLiteDatabase;:GetOpenOrCreateDatabase_Ljava_lang_String_ILandroid_database_sqlite_SQLiteDatabase_CursorFactory_Handler\n" +
			"n_openOrCreateDatabase:(Ljava/lang/String;ILandroid/database/sqlite/SQLiteDatabase$CursorFactory;Landroid/database/DatabaseErrorHandler;)Landroid/database/sqlite/SQLiteDatabase;:GetOpenOrCreateDatabase_Ljava_lang_String_ILandroid_database_sqlite_SQLiteDatabase_CursorFactory_Landroid_database_DatabaseErrorHandler_Handler\n" +
			"n_overridePendingTransition:(II)V:GetOverridePendingTransition_IIHandler\n" +
			"n_peekWallpaper:()Landroid/graphics/drawable/Drawable;:GetPeekWallpaperHandler\n" +
			"n_postponeEnterTransition:()V:GetPostponeEnterTransitionHandler\n" +
			"n_recreate:()V:GetRecreateHandler\n" +
			"n_registerComponentCallbacks:(Landroid/content/ComponentCallbacks;)V:GetRegisterComponentCallbacks_Landroid_content_ComponentCallbacks_Handler\n" +
			"n_registerForContextMenu:(Landroid/view/View;)V:GetRegisterForContextMenu_Landroid_view_View_Handler\n" +
			"n_registerReceiver:(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;)Landroid/content/Intent;:GetRegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_Handler\n" +
			"n_registerReceiver:(Landroid/content/BroadcastReceiver;Landroid/content/IntentFilter;Ljava/lang/String;Landroid/os/Handler;)Landroid/content/Intent;:GetRegisterReceiver_Landroid_content_BroadcastReceiver_Landroid_content_IntentFilter_Ljava_lang_String_Landroid_os_Handler_Handler\n" +
			"n_releaseInstance:()Z:GetReleaseInstanceHandler\n" +
			"n_removeStickyBroadcast:(Landroid/content/Intent;)V:GetRemoveStickyBroadcast_Landroid_content_Intent_Handler\n" +
			"n_removeStickyBroadcastAsUser:(Landroid/content/Intent;Landroid/os/UserHandle;)V:GetRemoveStickyBroadcastAsUser_Landroid_content_Intent_Landroid_os_UserHandle_Handler\n" +
			"n_reportFullyDrawn:()V:GetReportFullyDrawnHandler\n" +
			"n_requestVisibleBehind:(Z)Z:GetRequestVisibleBehind_ZHandler\n" +
			"n_revokeUriPermission:(Landroid/net/Uri;I)V:GetRevokeUriPermission_Landroid_net_Uri_IHandler\n" +
			"n_sendBroadcast:(Landroid/content/Intent;)V:GetSendBroadcast_Landroid_content_Intent_Handler\n" +
			"n_sendBroadcast:(Landroid/content/Intent;Ljava/lang/String;)V:GetSendBroadcast_Landroid_content_Intent_Ljava_lang_String_Handler\n" +
			"n_sendBroadcastAsUser:(Landroid/content/Intent;Landroid/os/UserHandle;)V:GetSendBroadcastAsUser_Landroid_content_Intent_Landroid_os_UserHandle_Handler\n" +
			"n_sendBroadcastAsUser:(Landroid/content/Intent;Landroid/os/UserHandle;Ljava/lang/String;)V:GetSendBroadcastAsUser_Landroid_content_Intent_Landroid_os_UserHandle_Ljava_lang_String_Handler\n" +
			"n_sendOrderedBroadcast:(Landroid/content/Intent;Ljava/lang/String;)V:GetSendOrderedBroadcast_Landroid_content_Intent_Ljava_lang_String_Handler\n" +
			"n_sendOrderedBroadcast:(Landroid/content/Intent;Ljava/lang/String;Landroid/content/BroadcastReceiver;Landroid/os/Handler;ILjava/lang/String;Landroid/os/Bundle;)V:GetSendOrderedBroadcast_Landroid_content_Intent_Ljava_lang_String_Landroid_content_BroadcastReceiver_Landroid_os_Handler_ILjava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_sendOrderedBroadcastAsUser:(Landroid/content/Intent;Landroid/os/UserHandle;Ljava/lang/String;Landroid/content/BroadcastReceiver;Landroid/os/Handler;ILjava/lang/String;Landroid/os/Bundle;)V:GetSendOrderedBroadcastAsUser_Landroid_content_Intent_Landroid_os_UserHandle_Ljava_lang_String_Landroid_content_BroadcastReceiver_Landroid_os_Handler_ILjava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_sendStickyBroadcast:(Landroid/content/Intent;)V:GetSendStickyBroadcast_Landroid_content_Intent_Handler\n" +
			"n_sendStickyBroadcastAsUser:(Landroid/content/Intent;Landroid/os/UserHandle;)V:GetSendStickyBroadcastAsUser_Landroid_content_Intent_Landroid_os_UserHandle_Handler\n" +
			"n_sendStickyOrderedBroadcast:(Landroid/content/Intent;Landroid/content/BroadcastReceiver;Landroid/os/Handler;ILjava/lang/String;Landroid/os/Bundle;)V:GetSendStickyOrderedBroadcast_Landroid_content_Intent_Landroid_content_BroadcastReceiver_Landroid_os_Handler_ILjava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_sendStickyOrderedBroadcastAsUser:(Landroid/content/Intent;Landroid/os/UserHandle;Landroid/content/BroadcastReceiver;Landroid/os/Handler;ILjava/lang/String;Landroid/os/Bundle;)V:GetSendStickyOrderedBroadcastAsUser_Landroid_content_Intent_Landroid_os_UserHandle_Landroid_content_BroadcastReceiver_Landroid_os_Handler_ILjava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_setActionBar:(Landroid/widget/Toolbar;)V:GetSetActionBar_Landroid_widget_Toolbar_Handler\n" +
			"n_setContentView:(Landroid/view/View;)V:GetSetContentView_Landroid_view_View_Handler\n" +
			"n_setContentView:(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V:GetSetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler\n" +
			"n_setContentView:(I)V:GetSetContentView_IHandler\n" +
			"n_setEnterSharedElementCallback:(Landroid/app/SharedElementCallback;)V:GetSetEnterSharedElementCallback_Landroid_app_SharedElementCallback_Handler\n" +
			"n_setEnterSharedElementCallback:(Landroid/support/v4/app/SharedElementCallback;)V:GetSetEnterSharedElementCallback_Landroid_support_v4_app_SharedElementCallback_Handler\n" +
			"n_setExitSharedElementCallback:(Landroid/app/SharedElementCallback;)V:GetSetExitSharedElementCallback_Landroid_app_SharedElementCallback_Handler\n" +
			"n_setExitSharedElementCallback:(Landroid/support/v4/app/SharedElementCallback;)V:GetSetExitSharedElementCallback_Landroid_support_v4_app_SharedElementCallback_Handler\n" +
			"n_setFinishOnTouchOutside:(Z)V:GetSetFinishOnTouchOutside_ZHandler\n" +
			"n_setPersistent:(Z)V:GetSetPersistent_ZHandler\n" +
			"n_setSupportActionBar:(Landroid/support/v7/widget/Toolbar;)V:GetSetSupportActionBar_Landroid_support_v7_widget_Toolbar_Handler\n" +
			"n_setSupportProgress:(I)V:GetSetSupportProgress_IHandler\n" +
			"n_setSupportProgressBarIndeterminate:(Z)V:GetSetSupportProgressBarIndeterminate_ZHandler\n" +
			"n_setSupportProgressBarIndeterminateVisibility:(Z)V:GetSetSupportProgressBarIndeterminateVisibility_ZHandler\n" +
			"n_setSupportProgressBarVisibility:(Z)V:GetSetSupportProgressBarVisibility_ZHandler\n" +
			"n_setTaskDescription:(Landroid/app/ActivityManager$TaskDescription;)V:GetSetTaskDescription_Landroid_app_ActivityManager_TaskDescription_Handler\n" +
			"n_setTheme:(I)V:GetSetTheme_IHandler\n" +
			"n_setTitle:(I)V:GetSetTitle_IHandler\n" +
			"n_setVisible:(Z)V:GetSetVisible_ZHandler\n" +
			"n_setWallpaper:(Landroid/graphics/Bitmap;)V:GetSetWallpaper_Landroid_graphics_Bitmap_Handler\n" +
			"n_setWallpaper:(Ljava/io/InputStream;)V:GetSetWallpaper_Ljava_io_InputStream_Handler\n" +
			"n_shouldShowRequestPermissionRationale:(Ljava/lang/String;)Z:GetShouldShowRequestPermissionRationale_Ljava_lang_String_Handler\n" +
			"n_shouldUpRecreateTask:(Landroid/content/Intent;)Z:GetShouldUpRecreateTask_Landroid_content_Intent_Handler\n" +
			"n_showAssist:(Landroid/os/Bundle;)Z:GetShowAssist_Landroid_os_Bundle_Handler\n" +
			"n_showLockTaskEscapeMessage:()V:GetShowLockTaskEscapeMessageHandler\n" +
			"n_startActionMode:(Landroid/view/ActionMode$Callback;)Landroid/view/ActionMode;:GetStartActionMode_Landroid_view_ActionMode_Callback_Handler\n" +
			"n_startActionMode:(Landroid/view/ActionMode$Callback;I)Landroid/view/ActionMode;:GetStartActionMode_Landroid_view_ActionMode_Callback_IHandler\n" +
			"n_startActivities:([Landroid/content/Intent;)V:GetStartActivities_arrayLandroid_content_Intent_Handler\n" +
			"n_startActivities:([Landroid/content/Intent;Landroid/os/Bundle;)V:GetStartActivities_arrayLandroid_content_Intent_Landroid_os_Bundle_Handler\n" +
			"n_startActivity:(Landroid/content/Intent;)V:GetStartActivity_Landroid_content_Intent_Handler\n" +
			"n_startActivity:(Landroid/content/Intent;Landroid/os/Bundle;)V:GetStartActivity_Landroid_content_Intent_Landroid_os_Bundle_Handler\n" +
			"n_startActivityForResult:(Landroid/content/Intent;I)V:GetStartActivityForResult_Landroid_content_Intent_IHandler\n" +
			"n_startActivityForResult:(Landroid/content/Intent;ILandroid/os/Bundle;)V:GetStartActivityForResult_Landroid_content_Intent_ILandroid_os_Bundle_Handler\n" +
			"n_startActivityFromChild:(Landroid/app/Activity;Landroid/content/Intent;I)V:GetStartActivityFromChild_Landroid_app_Activity_Landroid_content_Intent_IHandler\n" +
			"n_startActivityFromChild:(Landroid/app/Activity;Landroid/content/Intent;ILandroid/os/Bundle;)V:GetStartActivityFromChild_Landroid_app_Activity_Landroid_content_Intent_ILandroid_os_Bundle_Handler\n" +
			"n_startActivityFromFragment:(Landroid/app/Fragment;Landroid/content/Intent;I)V:GetStartActivityFromFragment_Landroid_app_Fragment_Landroid_content_Intent_IHandler\n" +
			"n_startActivityFromFragment:(Landroid/app/Fragment;Landroid/content/Intent;ILandroid/os/Bundle;)V:GetStartActivityFromFragment_Landroid_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_Handler\n" +
			"n_startActivityFromFragment:(Landroid/support/v4/app/Fragment;Landroid/content/Intent;I)V:GetStartActivityFromFragment_Landroid_support_v4_app_Fragment_Landroid_content_Intent_IHandler\n" +
			"n_startActivityFromFragment:(Landroid/support/v4/app/Fragment;Landroid/content/Intent;ILandroid/os/Bundle;)V:GetStartActivityFromFragment_Landroid_support_v4_app_Fragment_Landroid_content_Intent_ILandroid_os_Bundle_Handler\n" +
			"n_startActivityIfNeeded:(Landroid/content/Intent;I)Z:GetStartActivityIfNeeded_Landroid_content_Intent_IHandler\n" +
			"n_startActivityIfNeeded:(Landroid/content/Intent;ILandroid/os/Bundle;)Z:GetStartActivityIfNeeded_Landroid_content_Intent_ILandroid_os_Bundle_Handler\n" +
			"n_startInstrumentation:(Landroid/content/ComponentName;Ljava/lang/String;Landroid/os/Bundle;)Z:GetStartInstrumentation_Landroid_content_ComponentName_Ljava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_startIntentSender:(Landroid/content/IntentSender;Landroid/content/Intent;III)V:GetStartIntentSender_Landroid_content_IntentSender_Landroid_content_Intent_IIIHandler\n" +
			"n_startIntentSender:(Landroid/content/IntentSender;Landroid/content/Intent;IIILandroid/os/Bundle;)V:GetStartIntentSender_Landroid_content_IntentSender_Landroid_content_Intent_IIILandroid_os_Bundle_Handler\n" +
			"n_startIntentSenderForResult:(Landroid/content/IntentSender;ILandroid/content/Intent;III)V:GetStartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIIHandler\n" +
			"n_startIntentSenderForResult:(Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V:GetStartIntentSenderForResult_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler\n" +
			"n_startIntentSenderFromChild:(Landroid/app/Activity;Landroid/content/IntentSender;ILandroid/content/Intent;III)V:GetStartIntentSenderFromChild_Landroid_app_Activity_Landroid_content_IntentSender_ILandroid_content_Intent_IIIHandler\n" +
			"n_startIntentSenderFromChild:(Landroid/app/Activity;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V:GetStartIntentSenderFromChild_Landroid_app_Activity_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler\n" +
			"n_startIntentSenderFromFragment:(Landroid/support/v4/app/Fragment;Landroid/content/IntentSender;ILandroid/content/Intent;IIILandroid/os/Bundle;)V:GetStartIntentSenderFromFragment_Landroid_support_v4_app_Fragment_Landroid_content_IntentSender_ILandroid_content_Intent_IIILandroid_os_Bundle_Handler\n" +
			"n_startLockTask:()V:GetStartLockTaskHandler\n" +
			"n_startManagingCursor:(Landroid/database/Cursor;)V:GetStartManagingCursor_Landroid_database_Cursor_Handler\n" +
			"n_startNextMatchingActivity:(Landroid/content/Intent;)Z:GetStartNextMatchingActivity_Landroid_content_Intent_Handler\n" +
			"n_startNextMatchingActivity:(Landroid/content/Intent;Landroid/os/Bundle;)Z:GetStartNextMatchingActivity_Landroid_content_Intent_Landroid_os_Bundle_Handler\n" +
			"n_startPostponedEnterTransition:()V:GetStartPostponedEnterTransitionHandler\n" +
			"n_startSearch:(Ljava/lang/String;ZLandroid/os/Bundle;Z)V:GetStartSearch_Ljava_lang_String_ZLandroid_os_Bundle_ZHandler\n" +
			"n_startService:(Landroid/content/Intent;)Landroid/content/ComponentName;:GetStartService_Landroid_content_Intent_Handler\n" +
			"n_startSupportActionMode:(Landroid/support/v7/view/ActionMode$Callback;)Landroid/support/v7/view/ActionMode;:GetStartSupportActionMode_Landroid_support_v7_view_ActionMode_Callback_Handler\n" +
			"n_stopLockTask:()V:GetStopLockTaskHandler\n" +
			"n_stopManagingCursor:(Landroid/database/Cursor;)V:GetStopManagingCursor_Landroid_database_Cursor_Handler\n" +
			"n_stopService:(Landroid/content/Intent;)Z:GetStopService_Landroid_content_Intent_Handler\n" +
			"n_supportFinishAfterTransition:()V:GetSupportFinishAfterTransitionHandler\n" +
			"n_supportInvalidateOptionsMenu:()V:GetSupportInvalidateOptionsMenuHandler\n" +
			"n_supportNavigateUpTo:(Landroid/content/Intent;)V:GetSupportNavigateUpTo_Landroid_content_Intent_Handler\n" +
			"n_supportPostponeEnterTransition:()V:GetSupportPostponeEnterTransitionHandler\n" +
			"n_supportRequestWindowFeature:(I)Z:GetSupportRequestWindowFeature_IHandler\n" +
			"n_supportShouldUpRecreateTask:(Landroid/content/Intent;)Z:GetSupportShouldUpRecreateTask_Landroid_content_Intent_Handler\n" +
			"n_supportStartPostponedEnterTransition:()V:GetSupportStartPostponedEnterTransitionHandler\n" +
			"n_takeKeyEvents:(Z)V:GetTakeKeyEvents_ZHandler\n" +
			"n_toString:()Ljava/lang/String;:GetToStringHandler\n" +
			"n_triggerSearch:(Ljava/lang/String;Landroid/os/Bundle;)V:GetTriggerSearch_Ljava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_unbindService:(Landroid/content/ServiceConnection;)V:GetUnbindService_Landroid_content_ServiceConnection_Handler\n" +
			"n_unregisterComponentCallbacks:(Landroid/content/ComponentCallbacks;)V:GetUnregisterComponentCallbacks_Landroid_content_ComponentCallbacks_Handler\n" +
			"n_unregisterForContextMenu:(Landroid/view/View;)V:GetUnregisterForContextMenu_Landroid_view_View_Handler\n" +
			"n_unregisterReceiver:(Landroid/content/BroadcastReceiver;)V:GetUnregisterReceiver_Landroid_content_BroadcastReceiver_Handler\n" +
			"n_attachBaseContext:(Landroid/content/Context;)V:GetAttachBaseContext_Landroid_content_Context_Handler\n" +
			"n_clone:()Ljava/lang/Object;:GetCloneHandler\n" +
			"n_finalize:()V:GetJavaFinalizeHandler\n" +
			"n_onActivityResult:(IILandroid/content/Intent;)V:GetOnActivityResult_IILandroid_content_Intent_Handler\n" +
			"n_onApplyThemeResource:(Landroid/content/res/Resources$Theme;IZ)V:GetOnApplyThemeResource_Landroid_content_res_Resources_Theme_IZHandler\n" +
			"n_onChildTitleChanged:(Landroid/app/Activity;Ljava/lang/CharSequence;)V:GetOnChildTitleChanged_Landroid_app_Activity_Ljava_lang_CharSequence_Handler\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateDialog:(I)Landroid/app/Dialog;:GetOnCreateDialog_IHandler\n" +
			"n_onCreateDialog:(ILandroid/os/Bundle;)Landroid/app/Dialog;:GetOnCreateDialog_ILandroid_os_Bundle_Handler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"n_onNewIntent:(Landroid/content/Intent;)V:GetOnNewIntent_Landroid_content_Intent_Handler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onPostCreate:(Landroid/os/Bundle;)V:GetOnPostCreate_Landroid_os_Bundle_Handler\n" +
			"n_onPostResume:()V:GetOnPostResumeHandler\n" +
			"n_onPrepareDialog:(ILandroid/app/Dialog;)V:GetOnPrepareDialog_ILandroid_app_Dialog_Handler\n" +
			"n_onPrepareDialog:(ILandroid/app/Dialog;Landroid/os/Bundle;)V:GetOnPrepareDialog_ILandroid_app_Dialog_Landroid_os_Bundle_Handler\n" +
			"n_onPrepareOptionsPanel:(Landroid/view/View;Landroid/view/Menu;)Z:GetOnPrepareOptionsPanel_Landroid_view_View_Landroid_view_Menu_Handler\n" +
			"n_onRestart:()V:GetOnRestartHandler\n" +
			"n_onRestoreInstanceState:(Landroid/os/Bundle;)V:GetOnRestoreInstanceState_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onResumeFragments:()V:GetOnResumeFragmentsHandler\n" +
			"n_onSaveInstanceState:(Landroid/os/Bundle;)V:GetOnSaveInstanceState_Landroid_os_Bundle_Handler\n" +
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"n_onTitleChanged:(Ljava/lang/CharSequence;I)V:GetOnTitleChanged_Ljava_lang_CharSequence_IHandler\n" +
			"n_onUserLeaveHint:()V:GetOnUserLeaveHintHandler\n" +
			"";
		mono.android.Runtime.register ("Asawer.Droid.AsawerAppCompatActivity, Asawer.Droid", AsawerAppCompatActivity.class, __md_methods);
	}


	public AsawerAppCompatActivity ()
	{
		super ();
		if (getClass () == AsawerAppCompatActivity.class)
			mono.android.TypeManager.Activate ("Asawer.Droid.AsawerAppCompatActivity, Asawer.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean isRestricted ()
	{
		return n_isRestricted ();
	}

	private native boolean n_isRestricted ();


	public android.content.Context getApplicationContext ()
	{
		return n_getApplicationContext ();
	}

	private native android.content.Context n_getApplicationContext ();


	public android.content.pm.ApplicationInfo getApplicationInfo ()
	{
		return n_getApplicationInfo ();
	}

	private native android.content.pm.ApplicationInfo n_getApplicationInfo ();


	public android.content.res.AssetManager getAssets ()
	{
		return n_getAssets ();
	}

	private native android.content.res.AssetManager n_getAssets ();


	public android.content.Context getBaseContext ()
	{
		return n_getBaseContext ();
	}

	private native android.content.Context n_getBaseContext ();


	public java.io.File getCacheDir ()
	{
		return n_getCacheDir ();
	}

	private native java.io.File n_getCacheDir ();


	public java.lang.ClassLoader getClassLoader ()
	{
		return n_getClassLoader ();
	}

	private native java.lang.ClassLoader n_getClassLoader ();


	public java.io.File getCodeCacheDir ()
	{
		return n_getCodeCacheDir ();
	}

	private native java.io.File n_getCodeCacheDir ();


	public android.content.ContentResolver getContentResolver ()
	{
		return n_getContentResolver ();
	}

	private native android.content.ContentResolver n_getContentResolver ();


	public java.io.File getExternalCacheDir ()
	{
		return n_getExternalCacheDir ();
	}

	private native java.io.File n_getExternalCacheDir ();


	public java.io.File getFilesDir ()
	{
		return n_getFilesDir ();
	}

	private native java.io.File n_getFilesDir ();


	public android.os.Looper getMainLooper ()
	{
		return n_getMainLooper ();
	}

	private native android.os.Looper n_getMainLooper ();


	public java.io.File getNoBackupFilesDir ()
	{
		return n_getNoBackupFilesDir ();
	}

	private native java.io.File n_getNoBackupFilesDir ();


	public java.io.File getObbDir ()
	{
		return n_getObbDir ();
	}

	private native java.io.File n_getObbDir ();


	public java.lang.String getPackageCodePath ()
	{
		return n_getPackageCodePath ();
	}

	private native java.lang.String n_getPackageCodePath ();


	public android.content.pm.PackageManager getPackageManager ()
	{
		return n_getPackageManager ();
	}

	private native android.content.pm.PackageManager n_getPackageManager ();


	public java.lang.String getPackageName ()
	{
		return n_getPackageName ();
	}

	private native java.lang.String n_getPackageName ();


	public java.lang.String getPackageResourcePath ()
	{
		return n_getPackageResourcePath ();
	}

	private native java.lang.String n_getPackageResourcePath ();


	public android.content.res.Resources.Theme getTheme ()
	{
		return n_getTheme ();
	}

	private native android.content.res.Resources.Theme n_getTheme ();


	public android.graphics.drawable.Drawable getWallpaper ()
	{
		return n_getWallpaper ();
	}

	private native android.graphics.drawable.Drawable n_getWallpaper ();


	public int getWallpaperDesiredMinimumHeight ()
	{
		return n_getWallpaperDesiredMinimumHeight ();
	}

	private native int n_getWallpaperDesiredMinimumHeight ();


	public int getWallpaperDesiredMinimumWidth ()
	{
		return n_getWallpaperDesiredMinimumWidth ();
	}

	private native int n_getWallpaperDesiredMinimumWidth ();


	public android.app.ActionBar getActionBar ()
	{
		return n_getActionBar ();
	}

	private native android.app.ActionBar n_getActionBar ();


	public android.content.ComponentName getCallingActivity ()
	{
		return n_getCallingActivity ();
	}

	private native android.content.ComponentName n_getCallingActivity ();


	public java.lang.String getCallingPackage ()
	{
		return n_getCallingPackage ();
	}

	private native java.lang.String n_getCallingPackage ();


	public int getChangingConfigurations ()
	{
		return n_getChangingConfigurations ();
	}

	private native int n_getChangingConfigurations ();


	public android.content.ComponentName getComponentName ()
	{
		return n_getComponentName ();
	}

	private native android.content.ComponentName n_getComponentName ();


	public android.transition.Scene getContentScene ()
	{
		return n_getContentScene ();
	}

	private native android.transition.Scene n_getContentScene ();


	public android.transition.TransitionManager getContentTransitionManager ()
	{
		return n_getContentTransitionManager ();
	}

	private native android.transition.TransitionManager n_getContentTransitionManager ();


	public void setContentTransitionManager (android.transition.TransitionManager p0)
	{
		n_setContentTransitionManager (p0);
	}

	private native void n_setContentTransitionManager (android.transition.TransitionManager p0);


	public android.view.View getCurrentFocus ()
	{
		return n_getCurrentFocus ();
	}

	private native android.view.View n_getCurrentFocus ();


	public android.app.FragmentManager getFragmentManager ()
	{
		return n_getFragmentManager ();
	}

	private native android.app.FragmentManager n_getFragmentManager ();


	public boolean hasWindowFocus ()
	{
		return n_hasWindowFocus ();
	}

	private native boolean n_hasWindowFocus ();


	public boolean isImmersive ()
	{
		return n_isImmersive ();
	}

	private native boolean n_isImmersive ();


	public void setImmersive (boolean p0)
	{
		n_setImmersive (p0);
	}

	private native void n_setImmersive (boolean p0);


	public android.content.Intent getIntent ()
	{
		return n_getIntent ();
	}

	private native android.content.Intent n_getIntent ();


	public void setIntent (android.content.Intent p0)
	{
		n_setIntent (p0);
	}

	private native void n_setIntent (android.content.Intent p0);


	public boolean isChangingConfigurations ()
	{
		return n_isChangingConfigurations ();
	}

	private native boolean n_isChangingConfigurations ();


	public boolean isDestroyed ()
	{
		return n_isDestroyed ();
	}

	private native boolean n_isDestroyed ();


	public boolean isFinishing ()
	{
		return n_isFinishing ();
	}

	private native boolean n_isFinishing ();


	public boolean isTaskRoot ()
	{
		return n_isTaskRoot ();
	}

	private native boolean n_isTaskRoot ();


	public boolean isVoiceInteraction ()
	{
		return n_isVoiceInteraction ();
	}

	private native boolean n_isVoiceInteraction ();


	public boolean isVoiceInteractionRoot ()
	{
		return n_isVoiceInteractionRoot ();
	}

	private native boolean n_isVoiceInteractionRoot ();


	public java.lang.Object getLastNonConfigurationInstance ()
	{
		return n_getLastNonConfigurationInstance ();
	}

	private native java.lang.Object n_getLastNonConfigurationInstance ();


	public android.view.LayoutInflater getLayoutInflater ()
	{
		return n_getLayoutInflater ();
	}

	private native android.view.LayoutInflater n_getLayoutInflater ();


	public android.app.LoaderManager getLoaderManager ()
	{
		return n_getLoaderManager ();
	}

	private native android.app.LoaderManager n_getLoaderManager ();


	public java.lang.String getLocalClassName ()
	{
		return n_getLocalClassName ();
	}

	private native java.lang.String n_getLocalClassName ();


	public android.content.Intent getParentActivityIntent ()
	{
		return n_getParentActivityIntent ();
	}

	private native android.content.Intent n_getParentActivityIntent ();


	public android.net.Uri getReferrer ()
	{
		return n_getReferrer ();
	}

	private native android.net.Uri n_getReferrer ();


	public int getRequestedOrientation ()
	{
		return n_getRequestedOrientation ();
	}

	private native int n_getRequestedOrientation ();


	public void setRequestedOrientation (int p0)
	{
		n_setRequestedOrientation (p0);
	}

	private native void n_setRequestedOrientation (int p0);


	public int getTaskId ()
	{
		return n_getTaskId ();
	}

	private native int n_getTaskId ();


	public android.app.VoiceInteractor getVoiceInteractor ()
	{
		return n_getVoiceInteractor ();
	}

	private native android.app.VoiceInteractor n_getVoiceInteractor ();


	public android.view.Window getWindow ()
	{
		return n_getWindow ();
	}

	private native android.view.Window n_getWindow ();


	public android.view.WindowManager getWindowManager ()
	{
		return n_getWindowManager ();
	}

	private native android.view.WindowManager n_getWindowManager ();


	public java.lang.Object getLastCustomNonConfigurationInstance ()
	{
		return n_getLastCustomNonConfigurationInstance ();
	}

	private native java.lang.Object n_getLastCustomNonConfigurationInstance ();


	public android.support.v4.app.FragmentManager getSupportFragmentManager ()
	{
		return n_getSupportFragmentManager ();
	}

	private native android.support.v4.app.FragmentManager n_getSupportFragmentManager ();


	public android.support.v4.app.LoaderManager getSupportLoaderManager ()
	{
		return n_getSupportLoaderManager ();
	}

	private native android.support.v4.app.LoaderManager n_getSupportLoaderManager ();


	public android.support.v7.app.AppCompatDelegate getDelegate ()
	{
		return n_getDelegate ();
	}

	private native android.support.v7.app.AppCompatDelegate n_getDelegate ();


	public android.support.v7.app.ActionBarDrawerToggle.Delegate getDrawerToggleDelegate ()
	{
		return n_getDrawerToggleDelegate ();
	}

	private native android.support.v7.app.ActionBarDrawerToggle.Delegate n_getDrawerToggleDelegate ();


	public android.view.MenuInflater getMenuInflater ()
	{
		return n_getMenuInflater ();
	}

	private native android.view.MenuInflater n_getMenuInflater ();


	public android.content.res.Resources getResources ()
	{
		return n_getResources ();
	}

	private native android.content.res.Resources n_getResources ();


	public android.support.v7.app.ActionBar getSupportActionBar ()
	{
		return n_getSupportActionBar ();
	}

	private native android.support.v7.app.ActionBar n_getSupportActionBar ();


	public android.content.Intent getSupportParentActivityIntent ()
	{
		return n_getSupportParentActivityIntent ();
	}

	private native android.content.Intent n_getSupportParentActivityIntent ();


	public void addContentView (android.view.View p0, android.view.ViewGroup.LayoutParams p1)
	{
		n_addContentView (p0, p1);
	}

	private native void n_addContentView (android.view.View p0, android.view.ViewGroup.LayoutParams p1);


	public void applyOverrideConfiguration (android.content.res.Configuration p0)
	{
		n_applyOverrideConfiguration (p0);
	}

	private native void n_applyOverrideConfiguration (android.content.res.Configuration p0);


	public boolean bindService (android.content.Intent p0, android.content.ServiceConnection p1, int p2)
	{
		return n_bindService (p0, p1, p2);
	}

	private native boolean n_bindService (android.content.Intent p0, android.content.ServiceConnection p1, int p2);


	public int checkCallingOrSelfPermission (java.lang.String p0)
	{
		return n_checkCallingOrSelfPermission (p0);
	}

	private native int n_checkCallingOrSelfPermission (java.lang.String p0);


	public int checkCallingOrSelfUriPermission (android.net.Uri p0, int p1)
	{
		return n_checkCallingOrSelfUriPermission (p0, p1);
	}

	private native int n_checkCallingOrSelfUriPermission (android.net.Uri p0, int p1);


	public int checkCallingPermission (java.lang.String p0)
	{
		return n_checkCallingPermission (p0);
	}

	private native int n_checkCallingPermission (java.lang.String p0);


	public int checkCallingUriPermission (android.net.Uri p0, int p1)
	{
		return n_checkCallingUriPermission (p0, p1);
	}

	private native int n_checkCallingUriPermission (android.net.Uri p0, int p1);


	public int checkPermission (java.lang.String p0, int p1, int p2)
	{
		return n_checkPermission (p0, p1, p2);
	}

	private native int n_checkPermission (java.lang.String p0, int p1, int p2);


	public int checkSelfPermission (java.lang.String p0)
	{
		return n_checkSelfPermission (p0);
	}

	private native int n_checkSelfPermission (java.lang.String p0);


	public int checkUriPermission (android.net.Uri p0, int p1, int p2, int p3)
	{
		return n_checkUriPermission (p0, p1, p2, p3);
	}

	private native int n_checkUriPermission (android.net.Uri p0, int p1, int p2, int p3);


	public int checkUriPermission (android.net.Uri p0, java.lang.String p1, java.lang.String p2, int p3, int p4, int p5)
	{
		return n_checkUriPermission (p0, p1, p2, p3, p4, p5);
	}

	private native int n_checkUriPermission (android.net.Uri p0, java.lang.String p1, java.lang.String p2, int p3, int p4, int p5);


	public void clearWallpaper ()
	{
		n_clearWallpaper ();
	}

	private native void n_clearWallpaper ();


	public void closeContextMenu ()
	{
		n_closeContextMenu ();
	}

	private native void n_closeContextMenu ();


	public void closeOptionsMenu ()
	{
		n_closeOptionsMenu ();
	}

	private native void n_closeOptionsMenu ();


	public android.content.Context createConfigurationContext (android.content.res.Configuration p0)
	{
		return n_createConfigurationContext (p0);
	}

	private native android.content.Context n_createConfigurationContext (android.content.res.Configuration p0);


	public android.content.Context createDisplayContext (android.view.Display p0)
	{
		return n_createDisplayContext (p0);
	}

	private native android.content.Context n_createDisplayContext (android.view.Display p0);


	public android.content.Context createPackageContext (java.lang.String p0, int p1)
	{
		return n_createPackageContext (p0, p1);
	}

	private native android.content.Context n_createPackageContext (java.lang.String p0, int p1);


	public android.app.PendingIntent createPendingResult (int p0, android.content.Intent p1, int p2)
	{
		return n_createPendingResult (p0, p1, p2);
	}

	private native android.app.PendingIntent n_createPendingResult (int p0, android.content.Intent p1, int p2);


	public java.lang.String[] databaseList ()
	{
		return n_databaseList ();
	}

	private native java.lang.String[] n_databaseList ();


	public boolean deleteDatabase (java.lang.String p0)
	{
		return n_deleteDatabase (p0);
	}

	private native boolean n_deleteDatabase (java.lang.String p0);


	public boolean deleteFile (java.lang.String p0)
	{
		return n_deleteFile (p0);
	}

	private native boolean n_deleteFile (java.lang.String p0);


	public boolean dispatchGenericMotionEvent (android.view.MotionEvent p0)
	{
		return n_dispatchGenericMotionEvent (p0);
	}

	private native boolean n_dispatchGenericMotionEvent (android.view.MotionEvent p0);


	public boolean dispatchKeyEvent (android.view.KeyEvent p0)
	{
		return n_dispatchKeyEvent (p0);
	}

	private native boolean n_dispatchKeyEvent (android.view.KeyEvent p0);


	public boolean dispatchKeyShortcutEvent (android.view.KeyEvent p0)
	{
		return n_dispatchKeyShortcutEvent (p0);
	}

	private native boolean n_dispatchKeyShortcutEvent (android.view.KeyEvent p0);


	public boolean dispatchPopulateAccessibilityEvent (android.view.accessibility.AccessibilityEvent p0)
	{
		return n_dispatchPopulateAccessibilityEvent (p0);
	}

	private native boolean n_dispatchPopulateAccessibilityEvent (android.view.accessibility.AccessibilityEvent p0);


	public boolean dispatchTouchEvent (android.view.MotionEvent p0)
	{
		return n_dispatchTouchEvent (p0);
	}

	private native boolean n_dispatchTouchEvent (android.view.MotionEvent p0);


	public boolean dispatchTrackballEvent (android.view.MotionEvent p0)
	{
		return n_dispatchTrackballEvent (p0);
	}

	private native boolean n_dispatchTrackballEvent (android.view.MotionEvent p0);


	public void dump (java.lang.String p0, java.io.FileDescriptor p1, java.io.PrintWriter p2, java.lang.String[] p3)
	{
		n_dump (p0, p1, p2, p3);
	}

	private native void n_dump (java.lang.String p0, java.io.FileDescriptor p1, java.io.PrintWriter p2, java.lang.String[] p3);


	public void enforceCallingOrSelfPermission (java.lang.String p0, java.lang.String p1)
	{
		n_enforceCallingOrSelfPermission (p0, p1);
	}

	private native void n_enforceCallingOrSelfPermission (java.lang.String p0, java.lang.String p1);


	public void enforceCallingOrSelfUriPermission (android.net.Uri p0, int p1, java.lang.String p2)
	{
		n_enforceCallingOrSelfUriPermission (p0, p1, p2);
	}

	private native void n_enforceCallingOrSelfUriPermission (android.net.Uri p0, int p1, java.lang.String p2);


	public void enforceCallingPermission (java.lang.String p0, java.lang.String p1)
	{
		n_enforceCallingPermission (p0, p1);
	}

	private native void n_enforceCallingPermission (java.lang.String p0, java.lang.String p1);


	public void enforceCallingUriPermission (android.net.Uri p0, int p1, java.lang.String p2)
	{
		n_enforceCallingUriPermission (p0, p1, p2);
	}

	private native void n_enforceCallingUriPermission (android.net.Uri p0, int p1, java.lang.String p2);


	public void enforcePermission (java.lang.String p0, int p1, int p2, java.lang.String p3)
	{
		n_enforcePermission (p0, p1, p2, p3);
	}

	private native void n_enforcePermission (java.lang.String p0, int p1, int p2, java.lang.String p3);


	public void enforceUriPermission (android.net.Uri p0, int p1, int p2, int p3, java.lang.String p4)
	{
		n_enforceUriPermission (p0, p1, p2, p3, p4);
	}

	private native void n_enforceUriPermission (android.net.Uri p0, int p1, int p2, int p3, java.lang.String p4);


	public void enforceUriPermission (android.net.Uri p0, java.lang.String p1, java.lang.String p2, int p3, int p4, int p5, java.lang.String p6)
	{
		n_enforceUriPermission (p0, p1, p2, p3, p4, p5, p6);
	}

	private native void n_enforceUriPermission (android.net.Uri p0, java.lang.String p1, java.lang.String p2, int p3, int p4, int p5, java.lang.String p6);


	public boolean equals (java.lang.Object p0)
	{
		return n_equals (p0);
	}

	private native boolean n_equals (java.lang.Object p0);


	public java.lang.String[] fileList ()
	{
		return n_fileList ();
	}

	private native java.lang.String[] n_fileList ();


	public android.view.View findViewById (int p0)
	{
		return n_findViewById (p0);
	}

	private native android.view.View n_findViewById (int p0);


	public void finish ()
	{
		n_finish ();
	}

	private native void n_finish ();


	public void finishActivity (int p0)
	{
		n_finishActivity (p0);
	}

	private native void n_finishActivity (int p0);


	public void finishActivityFromChild (android.app.Activity p0, int p1)
	{
		n_finishActivityFromChild (p0, p1);
	}

	private native void n_finishActivityFromChild (android.app.Activity p0, int p1);


	public void finishAffinity ()
	{
		n_finishAffinity ();
	}

	private native void n_finishAffinity ();


	public void finishAfterTransition ()
	{
		n_finishAfterTransition ();
	}

	private native void n_finishAfterTransition ();


	public void finishAndRemoveTask ()
	{
		n_finishAndRemoveTask ();
	}

	private native void n_finishAndRemoveTask ();


	public void finishFromChild (android.app.Activity p0)
	{
		n_finishFromChild (p0);
	}

	private native void n_finishFromChild (android.app.Activity p0);


	public java.io.File getDatabasePath (java.lang.String p0)
	{
		return n_getDatabasePath (p0);
	}

	private native java.io.File n_getDatabasePath (java.lang.String p0);


	public java.io.File getDir (java.lang.String p0, int p1)
	{
		return n_getDir (p0, p1);
	}

	private native java.io.File n_getDir (java.lang.String p0, int p1);


	public java.io.File[] getExternalCacheDirs ()
	{
		return n_getExternalCacheDirs ();
	}

	private native java.io.File[] n_getExternalCacheDirs ();


	public java.io.File getExternalFilesDir (java.lang.String p0)
	{
		return n_getExternalFilesDir (p0);
	}

	private native java.io.File n_getExternalFilesDir (java.lang.String p0);


	public java.io.File[] getExternalFilesDirs (java.lang.String p0)
	{
		return n_getExternalFilesDirs (p0);
	}

	private native java.io.File[] n_getExternalFilesDirs (java.lang.String p0);


	public java.io.File[] getExternalMediaDirs ()
	{
		return n_getExternalMediaDirs ();
	}

	private native java.io.File[] n_getExternalMediaDirs ();


	public java.io.File getFileStreamPath (java.lang.String p0)
	{
		return n_getFileStreamPath (p0);
	}

	private native java.io.File n_getFileStreamPath (java.lang.String p0);


	public int hashCode ()
	{
		return n_hashCode ();
	}

	private native int n_hashCode ();


	public java.io.File[] getObbDirs ()
	{
		return n_getObbDirs ();
	}

	private native java.io.File[] n_getObbDirs ();


	public android.content.SharedPreferences getPreferences (int p0)
	{
		return n_getPreferences (p0);
	}

	private native android.content.SharedPreferences n_getPreferences (int p0);


	public android.content.SharedPreferences getSharedPreferences (java.lang.String p0, int p1)
	{
		return n_getSharedPreferences (p0, p1);
	}

	private native android.content.SharedPreferences n_getSharedPreferences (java.lang.String p0, int p1);


	public java.lang.Object getSystemService (java.lang.String p0)
	{
		return n_getSystemService (p0);
	}

	private native java.lang.Object n_getSystemService (java.lang.String p0);


	public java.lang.String getSystemServiceName (java.lang.Class p0)
	{
		return n_getSystemServiceName (p0);
	}

	private native java.lang.String n_getSystemServiceName (java.lang.Class p0);


	public void grantUriPermission (java.lang.String p0, android.net.Uri p1, int p2)
	{
		n_grantUriPermission (p0, p1, p2);
	}

	private native void n_grantUriPermission (java.lang.String p0, android.net.Uri p1, int p2);


	public void invalidateOptionsMenu ()
	{
		n_invalidateOptionsMenu ();
	}

	private native void n_invalidateOptionsMenu ();


	public boolean moveTaskToBack (boolean p0)
	{
		return n_moveTaskToBack (p0);
	}

	private native boolean n_moveTaskToBack (boolean p0);


	public boolean navigateUpTo (android.content.Intent p0)
	{
		return n_navigateUpTo (p0);
	}

	private native boolean n_navigateUpTo (android.content.Intent p0);


	public boolean navigateUpToFromChild (android.app.Activity p0, android.content.Intent p1)
	{
		return n_navigateUpToFromChild (p0, p1);
	}

	private native boolean n_navigateUpToFromChild (android.app.Activity p0, android.content.Intent p1);


	public void onActionModeFinished (android.view.ActionMode p0)
	{
		n_onActionModeFinished (p0);
	}

	private native void n_onActionModeFinished (android.view.ActionMode p0);


	public void onActionModeStarted (android.view.ActionMode p0)
	{
		n_onActionModeStarted (p0);
	}

	private native void n_onActionModeStarted (android.view.ActionMode p0);


	public void onActivityReenter (int p0, android.content.Intent p1)
	{
		n_onActivityReenter (p0, p1);
	}

	private native void n_onActivityReenter (int p0, android.content.Intent p1);


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();


	public void onAttachFragment (android.app.Fragment p0)
	{
		n_onAttachFragment (p0);
	}

	private native void n_onAttachFragment (android.app.Fragment p0);


	public void onAttachFragment (android.support.v4.app.Fragment p0)
	{
		n_onAttachFragment (p0);
	}

	private native void n_onAttachFragment (android.support.v4.app.Fragment p0);


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();


	public void onConfigurationChanged (android.content.res.Configuration p0)
	{
		n_onConfigurationChanged (p0);
	}

	private native void n_onConfigurationChanged (android.content.res.Configuration p0);


	public void onContentChanged ()
	{
		n_onContentChanged ();
	}

	private native void n_onContentChanged ();


	public boolean onContextItemSelected (android.view.MenuItem p0)
	{
		return n_onContextItemSelected (p0);
	}

	private native boolean n_onContextItemSelected (android.view.MenuItem p0);


	public void onContextMenuClosed (android.view.Menu p0)
	{
		n_onContextMenuClosed (p0);
	}

	private native void n_onContextMenuClosed (android.view.Menu p0);


	public void onCreate (android.os.Bundle p0, android.os.PersistableBundle p1)
	{
		n_onCreate (p0, p1);
	}

	private native void n_onCreate (android.os.Bundle p0, android.os.PersistableBundle p1);


	public void onCreateContextMenu (android.view.ContextMenu p0, android.view.View p1, android.view.ContextMenu.ContextMenuInfo p2)
	{
		n_onCreateContextMenu (p0, p1, p2);
	}

	private native void n_onCreateContextMenu (android.view.ContextMenu p0, android.view.View p1, android.view.ContextMenu.ContextMenuInfo p2);


	public java.lang.CharSequence onCreateDescription ()
	{
		return n_onCreateDescription ();
	}

	private native java.lang.CharSequence n_onCreateDescription ();


	public void onCreateNavigateUpTaskStack (android.app.TaskStackBuilder p0)
	{
		n_onCreateNavigateUpTaskStack (p0);
	}

	private native void n_onCreateNavigateUpTaskStack (android.app.TaskStackBuilder p0);


	public boolean onCreateOptionsMenu (android.view.Menu p0)
	{
		return n_onCreateOptionsMenu (p0);
	}

	private native boolean n_onCreateOptionsMenu (android.view.Menu p0);


	public boolean onCreatePanelMenu (int p0, android.view.Menu p1)
	{
		return n_onCreatePanelMenu (p0, p1);
	}

	private native boolean n_onCreatePanelMenu (int p0, android.view.Menu p1);


	public android.view.View onCreatePanelView (int p0)
	{
		return n_onCreatePanelView (p0);
	}

	private native android.view.View n_onCreatePanelView (int p0);


	public void onCreateSupportNavigateUpTaskStack (android.support.v4.app.TaskStackBuilder p0)
	{
		n_onCreateSupportNavigateUpTaskStack (p0);
	}

	private native void n_onCreateSupportNavigateUpTaskStack (android.support.v4.app.TaskStackBuilder p0);


	public boolean onCreateThumbnail (android.graphics.Bitmap p0, android.graphics.Canvas p1)
	{
		return n_onCreateThumbnail (p0, p1);
	}

	private native boolean n_onCreateThumbnail (android.graphics.Bitmap p0, android.graphics.Canvas p1);


	public android.view.View onCreateView (android.view.View p0, java.lang.String p1, android.content.Context p2, android.util.AttributeSet p3)
	{
		return n_onCreateView (p0, p1, p2, p3);
	}

	private native android.view.View n_onCreateView (android.view.View p0, java.lang.String p1, android.content.Context p2, android.util.AttributeSet p3);


	public android.view.View onCreateView (java.lang.String p0, android.content.Context p1, android.util.AttributeSet p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (java.lang.String p0, android.content.Context p1, android.util.AttributeSet p2);


	public void onDetachedFromWindow ()
	{
		n_onDetachedFromWindow ();
	}

	private native void n_onDetachedFromWindow ();


	public void onEnterAnimationComplete ()
	{
		n_onEnterAnimationComplete ();
	}

	private native void n_onEnterAnimationComplete ();


	public boolean onGenericMotionEvent (android.view.MotionEvent p0)
	{
		return n_onGenericMotionEvent (p0);
	}

	private native boolean n_onGenericMotionEvent (android.view.MotionEvent p0);


	public boolean onKeyDown (int p0, android.view.KeyEvent p1)
	{
		return n_onKeyDown (p0, p1);
	}

	private native boolean n_onKeyDown (int p0, android.view.KeyEvent p1);


	public boolean onKeyLongPress (int p0, android.view.KeyEvent p1)
	{
		return n_onKeyLongPress (p0, p1);
	}

	private native boolean n_onKeyLongPress (int p0, android.view.KeyEvent p1);


	public boolean onKeyMultiple (int p0, int p1, android.view.KeyEvent p2)
	{
		return n_onKeyMultiple (p0, p1, p2);
	}

	private native boolean n_onKeyMultiple (int p0, int p1, android.view.KeyEvent p2);


	public boolean onKeyShortcut (int p0, android.view.KeyEvent p1)
	{
		return n_onKeyShortcut (p0, p1);
	}

	private native boolean n_onKeyShortcut (int p0, android.view.KeyEvent p1);


	public boolean onKeyUp (int p0, android.view.KeyEvent p1)
	{
		return n_onKeyUp (p0, p1);
	}

	private native boolean n_onKeyUp (int p0, android.view.KeyEvent p1);


	public void onLowMemory ()
	{
		n_onLowMemory ();
	}

	private native void n_onLowMemory ();


	public boolean onMenuOpened (int p0, android.view.Menu p1)
	{
		return n_onMenuOpened (p0, p1);
	}

	private native boolean n_onMenuOpened (int p0, android.view.Menu p1);


	public void onMultiWindowModeChanged (boolean p0)
	{
		n_onMultiWindowModeChanged (p0);
	}

	private native void n_onMultiWindowModeChanged (boolean p0);


	public boolean onNavigateUp ()
	{
		return n_onNavigateUp ();
	}

	private native boolean n_onNavigateUp ();


	public boolean onNavigateUpFromChild (android.app.Activity p0)
	{
		return n_onNavigateUpFromChild (p0);
	}

	private native boolean n_onNavigateUpFromChild (android.app.Activity p0);


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);


	public void onOptionsMenuClosed (android.view.Menu p0)
	{
		n_onOptionsMenuClosed (p0);
	}

	private native void n_onOptionsMenuClosed (android.view.Menu p0);


	public void onPanelClosed (int p0, android.view.Menu p1)
	{
		n_onPanelClosed (p0, p1);
	}

	private native void n_onPanelClosed (int p0, android.view.Menu p1);


	public void onPictureInPictureModeChanged (boolean p0)
	{
		n_onPictureInPictureModeChanged (p0);
	}

	private native void n_onPictureInPictureModeChanged (boolean p0);


	public void onPostCreate (android.os.Bundle p0, android.os.PersistableBundle p1)
	{
		n_onPostCreate (p0, p1);
	}

	private native void n_onPostCreate (android.os.Bundle p0, android.os.PersistableBundle p1);


	public void onPrepareNavigateUpTaskStack (android.app.TaskStackBuilder p0)
	{
		n_onPrepareNavigateUpTaskStack (p0);
	}

	private native void n_onPrepareNavigateUpTaskStack (android.app.TaskStackBuilder p0);


	public boolean onPrepareOptionsMenu (android.view.Menu p0)
	{
		return n_onPrepareOptionsMenu (p0);
	}

	private native boolean n_onPrepareOptionsMenu (android.view.Menu p0);


	public boolean onPreparePanel (int p0, android.view.View p1, android.view.Menu p2)
	{
		return n_onPreparePanel (p0, p1, p2);
	}

	private native boolean n_onPreparePanel (int p0, android.view.View p1, android.view.Menu p2);


	public void onPrepareSupportNavigateUpTaskStack (android.support.v4.app.TaskStackBuilder p0)
	{
		n_onPrepareSupportNavigateUpTaskStack (p0);
	}

	private native void n_onPrepareSupportNavigateUpTaskStack (android.support.v4.app.TaskStackBuilder p0);


	public void onProvideAssistContent (android.app.assist.AssistContent p0)
	{
		n_onProvideAssistContent (p0);
	}

	private native void n_onProvideAssistContent (android.app.assist.AssistContent p0);


	public void onProvideAssistData (android.os.Bundle p0)
	{
		n_onProvideAssistData (p0);
	}

	private native void n_onProvideAssistData (android.os.Bundle p0);


	public android.net.Uri onProvideReferrer ()
	{
		return n_onProvideReferrer ();
	}

	private native android.net.Uri n_onProvideReferrer ();


	public void onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2)
	{
		n_onRequestPermissionsResult (p0, p1, p2);
	}

	private native void n_onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2);


	public void onRestoreInstanceState (android.os.Bundle p0, android.os.PersistableBundle p1)
	{
		n_onRestoreInstanceState (p0, p1);
	}

	private native void n_onRestoreInstanceState (android.os.Bundle p0, android.os.PersistableBundle p1);


	public java.lang.Object onRetainCustomNonConfigurationInstance ()
	{
		return n_onRetainCustomNonConfigurationInstance ();
	}

	private native java.lang.Object n_onRetainCustomNonConfigurationInstance ();


	public void onSaveInstanceState (android.os.Bundle p0, android.os.PersistableBundle p1)
	{
		n_onSaveInstanceState (p0, p1);
	}

	private native void n_onSaveInstanceState (android.os.Bundle p0, android.os.PersistableBundle p1);


	public boolean onSearchRequested ()
	{
		return n_onSearchRequested ();
	}

	private native boolean n_onSearchRequested ();


	public boolean onSearchRequested (android.view.SearchEvent p0)
	{
		return n_onSearchRequested (p0);
	}

	private native boolean n_onSearchRequested (android.view.SearchEvent p0);


	public void onStateNotSaved ()
	{
		n_onStateNotSaved ();
	}

	private native void n_onStateNotSaved ();


	public void onSupportActionModeFinished (android.support.v7.view.ActionMode p0)
	{
		n_onSupportActionModeFinished (p0);
	}

	private native void n_onSupportActionModeFinished (android.support.v7.view.ActionMode p0);


	public void onSupportActionModeStarted (android.support.v7.view.ActionMode p0)
	{
		n_onSupportActionModeStarted (p0);
	}

	private native void n_onSupportActionModeStarted (android.support.v7.view.ActionMode p0);


	public void onSupportContentChanged ()
	{
		n_onSupportContentChanged ();
	}

	private native void n_onSupportContentChanged ();


	public boolean onSupportNavigateUp ()
	{
		return n_onSupportNavigateUp ();
	}

	private native boolean n_onSupportNavigateUp ();


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);


	public boolean onTrackballEvent (android.view.MotionEvent p0)
	{
		return n_onTrackballEvent (p0);
	}

	private native boolean n_onTrackballEvent (android.view.MotionEvent p0);


	public void onTrimMemory (int p0)
	{
		n_onTrimMemory (p0);
	}

	private native void n_onTrimMemory (int p0);


	public void onUserInteraction ()
	{
		n_onUserInteraction ();
	}

	private native void n_onUserInteraction ();


	public void onVisibleBehindCanceled ()
	{
		n_onVisibleBehindCanceled ();
	}

	private native void n_onVisibleBehindCanceled ();


	public void onWindowAttributesChanged (android.view.WindowManager.LayoutParams p0)
	{
		n_onWindowAttributesChanged (p0);
	}

	private native void n_onWindowAttributesChanged (android.view.WindowManager.LayoutParams p0);


	public void onWindowFocusChanged (boolean p0)
	{
		n_onWindowFocusChanged (p0);
	}

	private native void n_onWindowFocusChanged (boolean p0);


	public android.view.ActionMode onWindowStartingActionMode (android.view.ActionMode.Callback p0)
	{
		return n_onWindowStartingActionMode (p0);
	}

	private native android.view.ActionMode n_onWindowStartingActionMode (android.view.ActionMode.Callback p0);


	public android.view.ActionMode onWindowStartingActionMode (android.view.ActionMode.Callback p0, int p1)
	{
		return n_onWindowStartingActionMode (p0, p1);
	}

	private native android.view.ActionMode n_onWindowStartingActionMode (android.view.ActionMode.Callback p0, int p1);


	public android.support.v7.view.ActionMode onWindowStartingSupportActionMode (android.support.v7.view.ActionMode.Callback p0)
	{
		return n_onWindowStartingSupportActionMode (p0);
	}

	private native android.support.v7.view.ActionMode n_onWindowStartingSupportActionMode (android.support.v7.view.ActionMode.Callback p0);


	public void openContextMenu (android.view.View p0)
	{
		n_openContextMenu (p0);
	}

	private native void n_openContextMenu (android.view.View p0);


	public java.io.FileInputStream openFileInput (java.lang.String p0)
	{
		return n_openFileInput (p0);
	}

	private native java.io.FileInputStream n_openFileInput (java.lang.String p0);


	public java.io.FileOutputStream openFileOutput (java.lang.String p0, int p1)
	{
		return n_openFileOutput (p0, p1);
	}

	private native java.io.FileOutputStream n_openFileOutput (java.lang.String p0, int p1);


	public void openOptionsMenu ()
	{
		n_openOptionsMenu ();
	}

	private native void n_openOptionsMenu ();


	public android.database.sqlite.SQLiteDatabase openOrCreateDatabase (java.lang.String p0, int p1, android.database.sqlite.SQLiteDatabase.CursorFactory p2)
	{
		return n_openOrCreateDatabase (p0, p1, p2);
	}

	private native android.database.sqlite.SQLiteDatabase n_openOrCreateDatabase (java.lang.String p0, int p1, android.database.sqlite.SQLiteDatabase.CursorFactory p2);


	public android.database.sqlite.SQLiteDatabase openOrCreateDatabase (java.lang.String p0, int p1, android.database.sqlite.SQLiteDatabase.CursorFactory p2, android.database.DatabaseErrorHandler p3)
	{
		return n_openOrCreateDatabase (p0, p1, p2, p3);
	}

	private native android.database.sqlite.SQLiteDatabase n_openOrCreateDatabase (java.lang.String p0, int p1, android.database.sqlite.SQLiteDatabase.CursorFactory p2, android.database.DatabaseErrorHandler p3);


	public void overridePendingTransition (int p0, int p1)
	{
		n_overridePendingTransition (p0, p1);
	}

	private native void n_overridePendingTransition (int p0, int p1);


	public android.graphics.drawable.Drawable peekWallpaper ()
	{
		return n_peekWallpaper ();
	}

	private native android.graphics.drawable.Drawable n_peekWallpaper ();


	public void postponeEnterTransition ()
	{
		n_postponeEnterTransition ();
	}

	private native void n_postponeEnterTransition ();


	public void recreate ()
	{
		n_recreate ();
	}

	private native void n_recreate ();


	public void registerComponentCallbacks (android.content.ComponentCallbacks p0)
	{
		n_registerComponentCallbacks (p0);
	}

	private native void n_registerComponentCallbacks (android.content.ComponentCallbacks p0);


	public void registerForContextMenu (android.view.View p0)
	{
		n_registerForContextMenu (p0);
	}

	private native void n_registerForContextMenu (android.view.View p0);


	public android.content.Intent registerReceiver (android.content.BroadcastReceiver p0, android.content.IntentFilter p1)
	{
		return n_registerReceiver (p0, p1);
	}

	private native android.content.Intent n_registerReceiver (android.content.BroadcastReceiver p0, android.content.IntentFilter p1);


	public android.content.Intent registerReceiver (android.content.BroadcastReceiver p0, android.content.IntentFilter p1, java.lang.String p2, android.os.Handler p3)
	{
		return n_registerReceiver (p0, p1, p2, p3);
	}

	private native android.content.Intent n_registerReceiver (android.content.BroadcastReceiver p0, android.content.IntentFilter p1, java.lang.String p2, android.os.Handler p3);


	public boolean releaseInstance ()
	{
		return n_releaseInstance ();
	}

	private native boolean n_releaseInstance ();


	public void removeStickyBroadcast (android.content.Intent p0)
	{
		n_removeStickyBroadcast (p0);
	}

	private native void n_removeStickyBroadcast (android.content.Intent p0);


	public void removeStickyBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1)
	{
		n_removeStickyBroadcastAsUser (p0, p1);
	}

	private native void n_removeStickyBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1);


	public void reportFullyDrawn ()
	{
		n_reportFullyDrawn ();
	}

	private native void n_reportFullyDrawn ();


	public boolean requestVisibleBehind (boolean p0)
	{
		return n_requestVisibleBehind (p0);
	}

	private native boolean n_requestVisibleBehind (boolean p0);


	public void revokeUriPermission (android.net.Uri p0, int p1)
	{
		n_revokeUriPermission (p0, p1);
	}

	private native void n_revokeUriPermission (android.net.Uri p0, int p1);


	public void sendBroadcast (android.content.Intent p0)
	{
		n_sendBroadcast (p0);
	}

	private native void n_sendBroadcast (android.content.Intent p0);


	public void sendBroadcast (android.content.Intent p0, java.lang.String p1)
	{
		n_sendBroadcast (p0, p1);
	}

	private native void n_sendBroadcast (android.content.Intent p0, java.lang.String p1);


	public void sendBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1)
	{
		n_sendBroadcastAsUser (p0, p1);
	}

	private native void n_sendBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1);


	public void sendBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1, java.lang.String p2)
	{
		n_sendBroadcastAsUser (p0, p1, p2);
	}

	private native void n_sendBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1, java.lang.String p2);


	public void sendOrderedBroadcast (android.content.Intent p0, java.lang.String p1)
	{
		n_sendOrderedBroadcast (p0, p1);
	}

	private native void n_sendOrderedBroadcast (android.content.Intent p0, java.lang.String p1);


	public void sendOrderedBroadcast (android.content.Intent p0, java.lang.String p1, android.content.BroadcastReceiver p2, android.os.Handler p3, int p4, java.lang.String p5, android.os.Bundle p6)
	{
		n_sendOrderedBroadcast (p0, p1, p2, p3, p4, p5, p6);
	}

	private native void n_sendOrderedBroadcast (android.content.Intent p0, java.lang.String p1, android.content.BroadcastReceiver p2, android.os.Handler p3, int p4, java.lang.String p5, android.os.Bundle p6);


	public void sendOrderedBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1, java.lang.String p2, android.content.BroadcastReceiver p3, android.os.Handler p4, int p5, java.lang.String p6, android.os.Bundle p7)
	{
		n_sendOrderedBroadcastAsUser (p0, p1, p2, p3, p4, p5, p6, p7);
	}

	private native void n_sendOrderedBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1, java.lang.String p2, android.content.BroadcastReceiver p3, android.os.Handler p4, int p5, java.lang.String p6, android.os.Bundle p7);


	public void sendStickyBroadcast (android.content.Intent p0)
	{
		n_sendStickyBroadcast (p0);
	}

	private native void n_sendStickyBroadcast (android.content.Intent p0);


	public void sendStickyBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1)
	{
		n_sendStickyBroadcastAsUser (p0, p1);
	}

	private native void n_sendStickyBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1);


	public void sendStickyOrderedBroadcast (android.content.Intent p0, android.content.BroadcastReceiver p1, android.os.Handler p2, int p3, java.lang.String p4, android.os.Bundle p5)
	{
		n_sendStickyOrderedBroadcast (p0, p1, p2, p3, p4, p5);
	}

	private native void n_sendStickyOrderedBroadcast (android.content.Intent p0, android.content.BroadcastReceiver p1, android.os.Handler p2, int p3, java.lang.String p4, android.os.Bundle p5);


	public void sendStickyOrderedBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1, android.content.BroadcastReceiver p2, android.os.Handler p3, int p4, java.lang.String p5, android.os.Bundle p6)
	{
		n_sendStickyOrderedBroadcastAsUser (p0, p1, p2, p3, p4, p5, p6);
	}

	private native void n_sendStickyOrderedBroadcastAsUser (android.content.Intent p0, android.os.UserHandle p1, android.content.BroadcastReceiver p2, android.os.Handler p3, int p4, java.lang.String p5, android.os.Bundle p6);


	public void setActionBar (android.widget.Toolbar p0)
	{
		n_setActionBar (p0);
	}

	private native void n_setActionBar (android.widget.Toolbar p0);


	public void setContentView (android.view.View p0)
	{
		n_setContentView (p0);
	}

	private native void n_setContentView (android.view.View p0);


	public void setContentView (android.view.View p0, android.view.ViewGroup.LayoutParams p1)
	{
		n_setContentView (p0, p1);
	}

	private native void n_setContentView (android.view.View p0, android.view.ViewGroup.LayoutParams p1);


	public void setContentView (int p0)
	{
		n_setContentView (p0);
	}

	private native void n_setContentView (int p0);


	public void setEnterSharedElementCallback (android.app.SharedElementCallback p0)
	{
		n_setEnterSharedElementCallback (p0);
	}

	private native void n_setEnterSharedElementCallback (android.app.SharedElementCallback p0);


	public void setEnterSharedElementCallback (android.support.v4.app.SharedElementCallback p0)
	{
		n_setEnterSharedElementCallback (p0);
	}

	private native void n_setEnterSharedElementCallback (android.support.v4.app.SharedElementCallback p0);


	public void setExitSharedElementCallback (android.app.SharedElementCallback p0)
	{
		n_setExitSharedElementCallback (p0);
	}

	private native void n_setExitSharedElementCallback (android.app.SharedElementCallback p0);


	public void setExitSharedElementCallback (android.support.v4.app.SharedElementCallback p0)
	{
		n_setExitSharedElementCallback (p0);
	}

	private native void n_setExitSharedElementCallback (android.support.v4.app.SharedElementCallback p0);


	public void setFinishOnTouchOutside (boolean p0)
	{
		n_setFinishOnTouchOutside (p0);
	}

	private native void n_setFinishOnTouchOutside (boolean p0);


	public void setPersistent (boolean p0)
	{
		n_setPersistent (p0);
	}

	private native void n_setPersistent (boolean p0);


	public void setSupportActionBar (android.support.v7.widget.Toolbar p0)
	{
		n_setSupportActionBar (p0);
	}

	private native void n_setSupportActionBar (android.support.v7.widget.Toolbar p0);


	public void setSupportProgress (int p0)
	{
		n_setSupportProgress (p0);
	}

	private native void n_setSupportProgress (int p0);


	public void setSupportProgressBarIndeterminate (boolean p0)
	{
		n_setSupportProgressBarIndeterminate (p0);
	}

	private native void n_setSupportProgressBarIndeterminate (boolean p0);


	public void setSupportProgressBarIndeterminateVisibility (boolean p0)
	{
		n_setSupportProgressBarIndeterminateVisibility (p0);
	}

	private native void n_setSupportProgressBarIndeterminateVisibility (boolean p0);


	public void setSupportProgressBarVisibility (boolean p0)
	{
		n_setSupportProgressBarVisibility (p0);
	}

	private native void n_setSupportProgressBarVisibility (boolean p0);


	public void setTaskDescription (android.app.ActivityManager.TaskDescription p0)
	{
		n_setTaskDescription (p0);
	}

	private native void n_setTaskDescription (android.app.ActivityManager.TaskDescription p0);


	public void setTheme (int p0)
	{
		n_setTheme (p0);
	}

	private native void n_setTheme (int p0);


	public void setTitle (int p0)
	{
		n_setTitle (p0);
	}

	private native void n_setTitle (int p0);


	public void setVisible (boolean p0)
	{
		n_setVisible (p0);
	}

	private native void n_setVisible (boolean p0);


	public void setWallpaper (android.graphics.Bitmap p0)
	{
		n_setWallpaper (p0);
	}

	private native void n_setWallpaper (android.graphics.Bitmap p0);


	public void setWallpaper (java.io.InputStream p0)
	{
		n_setWallpaper (p0);
	}

	private native void n_setWallpaper (java.io.InputStream p0);


	public boolean shouldShowRequestPermissionRationale (java.lang.String p0)
	{
		return n_shouldShowRequestPermissionRationale (p0);
	}

	private native boolean n_shouldShowRequestPermissionRationale (java.lang.String p0);


	public boolean shouldUpRecreateTask (android.content.Intent p0)
	{
		return n_shouldUpRecreateTask (p0);
	}

	private native boolean n_shouldUpRecreateTask (android.content.Intent p0);


	public boolean showAssist (android.os.Bundle p0)
	{
		return n_showAssist (p0);
	}

	private native boolean n_showAssist (android.os.Bundle p0);


	public void showLockTaskEscapeMessage ()
	{
		n_showLockTaskEscapeMessage ();
	}

	private native void n_showLockTaskEscapeMessage ();


	public android.view.ActionMode startActionMode (android.view.ActionMode.Callback p0)
	{
		return n_startActionMode (p0);
	}

	private native android.view.ActionMode n_startActionMode (android.view.ActionMode.Callback p0);


	public android.view.ActionMode startActionMode (android.view.ActionMode.Callback p0, int p1)
	{
		return n_startActionMode (p0, p1);
	}

	private native android.view.ActionMode n_startActionMode (android.view.ActionMode.Callback p0, int p1);


	public void startActivities (android.content.Intent[] p0)
	{
		n_startActivities (p0);
	}

	private native void n_startActivities (android.content.Intent[] p0);


	public void startActivities (android.content.Intent[] p0, android.os.Bundle p1)
	{
		n_startActivities (p0, p1);
	}

	private native void n_startActivities (android.content.Intent[] p0, android.os.Bundle p1);


	public void startActivity (android.content.Intent p0)
	{
		n_startActivity (p0);
	}

	private native void n_startActivity (android.content.Intent p0);


	public void startActivity (android.content.Intent p0, android.os.Bundle p1)
	{
		n_startActivity (p0, p1);
	}

	private native void n_startActivity (android.content.Intent p0, android.os.Bundle p1);


	public void startActivityForResult (android.content.Intent p0, int p1)
	{
		n_startActivityForResult (p0, p1);
	}

	private native void n_startActivityForResult (android.content.Intent p0, int p1);


	public void startActivityForResult (android.content.Intent p0, int p1, android.os.Bundle p2)
	{
		n_startActivityForResult (p0, p1, p2);
	}

	private native void n_startActivityForResult (android.content.Intent p0, int p1, android.os.Bundle p2);


	public void startActivityFromChild (android.app.Activity p0, android.content.Intent p1, int p2)
	{
		n_startActivityFromChild (p0, p1, p2);
	}

	private native void n_startActivityFromChild (android.app.Activity p0, android.content.Intent p1, int p2);


	public void startActivityFromChild (android.app.Activity p0, android.content.Intent p1, int p2, android.os.Bundle p3)
	{
		n_startActivityFromChild (p0, p1, p2, p3);
	}

	private native void n_startActivityFromChild (android.app.Activity p0, android.content.Intent p1, int p2, android.os.Bundle p3);


	public void startActivityFromFragment (android.app.Fragment p0, android.content.Intent p1, int p2)
	{
		n_startActivityFromFragment (p0, p1, p2);
	}

	private native void n_startActivityFromFragment (android.app.Fragment p0, android.content.Intent p1, int p2);


	public void startActivityFromFragment (android.app.Fragment p0, android.content.Intent p1, int p2, android.os.Bundle p3)
	{
		n_startActivityFromFragment (p0, p1, p2, p3);
	}

	private native void n_startActivityFromFragment (android.app.Fragment p0, android.content.Intent p1, int p2, android.os.Bundle p3);


	public void startActivityFromFragment (android.support.v4.app.Fragment p0, android.content.Intent p1, int p2)
	{
		n_startActivityFromFragment (p0, p1, p2);
	}

	private native void n_startActivityFromFragment (android.support.v4.app.Fragment p0, android.content.Intent p1, int p2);


	public void startActivityFromFragment (android.support.v4.app.Fragment p0, android.content.Intent p1, int p2, android.os.Bundle p3)
	{
		n_startActivityFromFragment (p0, p1, p2, p3);
	}

	private native void n_startActivityFromFragment (android.support.v4.app.Fragment p0, android.content.Intent p1, int p2, android.os.Bundle p3);


	public boolean startActivityIfNeeded (android.content.Intent p0, int p1)
	{
		return n_startActivityIfNeeded (p0, p1);
	}

	private native boolean n_startActivityIfNeeded (android.content.Intent p0, int p1);


	public boolean startActivityIfNeeded (android.content.Intent p0, int p1, android.os.Bundle p2)
	{
		return n_startActivityIfNeeded (p0, p1, p2);
	}

	private native boolean n_startActivityIfNeeded (android.content.Intent p0, int p1, android.os.Bundle p2);


	public boolean startInstrumentation (android.content.ComponentName p0, java.lang.String p1, android.os.Bundle p2)
	{
		return n_startInstrumentation (p0, p1, p2);
	}

	private native boolean n_startInstrumentation (android.content.ComponentName p0, java.lang.String p1, android.os.Bundle p2);


	public void startIntentSender (android.content.IntentSender p0, android.content.Intent p1, int p2, int p3, int p4)
	{
		n_startIntentSender (p0, p1, p2, p3, p4);
	}

	private native void n_startIntentSender (android.content.IntentSender p0, android.content.Intent p1, int p2, int p3, int p4);


	public void startIntentSender (android.content.IntentSender p0, android.content.Intent p1, int p2, int p3, int p4, android.os.Bundle p5)
	{
		n_startIntentSender (p0, p1, p2, p3, p4, p5);
	}

	private native void n_startIntentSender (android.content.IntentSender p0, android.content.Intent p1, int p2, int p3, int p4, android.os.Bundle p5);


	public void startIntentSenderForResult (android.content.IntentSender p0, int p1, android.content.Intent p2, int p3, int p4, int p5)
	{
		n_startIntentSenderForResult (p0, p1, p2, p3, p4, p5);
	}

	private native void n_startIntentSenderForResult (android.content.IntentSender p0, int p1, android.content.Intent p2, int p3, int p4, int p5);


	public void startIntentSenderForResult (android.content.IntentSender p0, int p1, android.content.Intent p2, int p3, int p4, int p5, android.os.Bundle p6)
	{
		n_startIntentSenderForResult (p0, p1, p2, p3, p4, p5, p6);
	}

	private native void n_startIntentSenderForResult (android.content.IntentSender p0, int p1, android.content.Intent p2, int p3, int p4, int p5, android.os.Bundle p6);


	public void startIntentSenderFromChild (android.app.Activity p0, android.content.IntentSender p1, int p2, android.content.Intent p3, int p4, int p5, int p6)
	{
		n_startIntentSenderFromChild (p0, p1, p2, p3, p4, p5, p6);
	}

	private native void n_startIntentSenderFromChild (android.app.Activity p0, android.content.IntentSender p1, int p2, android.content.Intent p3, int p4, int p5, int p6);


	public void startIntentSenderFromChild (android.app.Activity p0, android.content.IntentSender p1, int p2, android.content.Intent p3, int p4, int p5, int p6, android.os.Bundle p7)
	{
		n_startIntentSenderFromChild (p0, p1, p2, p3, p4, p5, p6, p7);
	}

	private native void n_startIntentSenderFromChild (android.app.Activity p0, android.content.IntentSender p1, int p2, android.content.Intent p3, int p4, int p5, int p6, android.os.Bundle p7);


	public void startIntentSenderFromFragment (android.support.v4.app.Fragment p0, android.content.IntentSender p1, int p2, android.content.Intent p3, int p4, int p5, int p6, android.os.Bundle p7)
	{
		n_startIntentSenderFromFragment (p0, p1, p2, p3, p4, p5, p6, p7);
	}

	private native void n_startIntentSenderFromFragment (android.support.v4.app.Fragment p0, android.content.IntentSender p1, int p2, android.content.Intent p3, int p4, int p5, int p6, android.os.Bundle p7);


	public void startLockTask ()
	{
		n_startLockTask ();
	}

	private native void n_startLockTask ();


	public void startManagingCursor (android.database.Cursor p0)
	{
		n_startManagingCursor (p0);
	}

	private native void n_startManagingCursor (android.database.Cursor p0);


	public boolean startNextMatchingActivity (android.content.Intent p0)
	{
		return n_startNextMatchingActivity (p0);
	}

	private native boolean n_startNextMatchingActivity (android.content.Intent p0);


	public boolean startNextMatchingActivity (android.content.Intent p0, android.os.Bundle p1)
	{
		return n_startNextMatchingActivity (p0, p1);
	}

	private native boolean n_startNextMatchingActivity (android.content.Intent p0, android.os.Bundle p1);


	public void startPostponedEnterTransition ()
	{
		n_startPostponedEnterTransition ();
	}

	private native void n_startPostponedEnterTransition ();


	public void startSearch (java.lang.String p0, boolean p1, android.os.Bundle p2, boolean p3)
	{
		n_startSearch (p0, p1, p2, p3);
	}

	private native void n_startSearch (java.lang.String p0, boolean p1, android.os.Bundle p2, boolean p3);


	public android.content.ComponentName startService (android.content.Intent p0)
	{
		return n_startService (p0);
	}

	private native android.content.ComponentName n_startService (android.content.Intent p0);


	public android.support.v7.view.ActionMode startSupportActionMode (android.support.v7.view.ActionMode.Callback p0)
	{
		return n_startSupportActionMode (p0);
	}

	private native android.support.v7.view.ActionMode n_startSupportActionMode (android.support.v7.view.ActionMode.Callback p0);


	public void stopLockTask ()
	{
		n_stopLockTask ();
	}

	private native void n_stopLockTask ();


	public void stopManagingCursor (android.database.Cursor p0)
	{
		n_stopManagingCursor (p0);
	}

	private native void n_stopManagingCursor (android.database.Cursor p0);


	public boolean stopService (android.content.Intent p0)
	{
		return n_stopService (p0);
	}

	private native boolean n_stopService (android.content.Intent p0);


	public void supportFinishAfterTransition ()
	{
		n_supportFinishAfterTransition ();
	}

	private native void n_supportFinishAfterTransition ();


	public void supportInvalidateOptionsMenu ()
	{
		n_supportInvalidateOptionsMenu ();
	}

	private native void n_supportInvalidateOptionsMenu ();


	public void supportNavigateUpTo (android.content.Intent p0)
	{
		n_supportNavigateUpTo (p0);
	}

	private native void n_supportNavigateUpTo (android.content.Intent p0);


	public void supportPostponeEnterTransition ()
	{
		n_supportPostponeEnterTransition ();
	}

	private native void n_supportPostponeEnterTransition ();


	public boolean supportRequestWindowFeature (int p0)
	{
		return n_supportRequestWindowFeature (p0);
	}

	private native boolean n_supportRequestWindowFeature (int p0);


	public boolean supportShouldUpRecreateTask (android.content.Intent p0)
	{
		return n_supportShouldUpRecreateTask (p0);
	}

	private native boolean n_supportShouldUpRecreateTask (android.content.Intent p0);


	public void supportStartPostponedEnterTransition ()
	{
		n_supportStartPostponedEnterTransition ();
	}

	private native void n_supportStartPostponedEnterTransition ();


	public void takeKeyEvents (boolean p0)
	{
		n_takeKeyEvents (p0);
	}

	private native void n_takeKeyEvents (boolean p0);


	public java.lang.String toString ()
	{
		return n_toString ();
	}

	private native java.lang.String n_toString ();


	public void triggerSearch (java.lang.String p0, android.os.Bundle p1)
	{
		n_triggerSearch (p0, p1);
	}

	private native void n_triggerSearch (java.lang.String p0, android.os.Bundle p1);


	public void unbindService (android.content.ServiceConnection p0)
	{
		n_unbindService (p0);
	}

	private native void n_unbindService (android.content.ServiceConnection p0);


	public void unregisterComponentCallbacks (android.content.ComponentCallbacks p0)
	{
		n_unregisterComponentCallbacks (p0);
	}

	private native void n_unregisterComponentCallbacks (android.content.ComponentCallbacks p0);


	public void unregisterForContextMenu (android.view.View p0)
	{
		n_unregisterForContextMenu (p0);
	}

	private native void n_unregisterForContextMenu (android.view.View p0);


	public void unregisterReceiver (android.content.BroadcastReceiver p0)
	{
		n_unregisterReceiver (p0);
	}

	private native void n_unregisterReceiver (android.content.BroadcastReceiver p0);


	public void attachBaseContext (android.content.Context p0)
	{
		n_attachBaseContext (p0);
	}

	private native void n_attachBaseContext (android.content.Context p0);


	public java.lang.Object clone ()
	{
		return n_clone ();
	}

	private native java.lang.Object n_clone ();


	public void finalize ()
	{
		n_finalize ();
	}

	private native void n_finalize ();


	public void onActivityResult (int p0, int p1, android.content.Intent p2)
	{
		n_onActivityResult (p0, p1, p2);
	}

	private native void n_onActivityResult (int p0, int p1, android.content.Intent p2);


	public void onApplyThemeResource (android.content.res.Resources.Theme p0, int p1, boolean p2)
	{
		n_onApplyThemeResource (p0, p1, p2);
	}

	private native void n_onApplyThemeResource (android.content.res.Resources.Theme p0, int p1, boolean p2);


	public void onChildTitleChanged (android.app.Activity p0, java.lang.CharSequence p1)
	{
		n_onChildTitleChanged (p0, p1);
	}

	private native void n_onChildTitleChanged (android.app.Activity p0, java.lang.CharSequence p1);


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.app.Dialog onCreateDialog (int p0)
	{
		return n_onCreateDialog (p0);
	}

	private native android.app.Dialog n_onCreateDialog (int p0);


	public android.app.Dialog onCreateDialog (int p0, android.os.Bundle p1)
	{
		return n_onCreateDialog (p0, p1);
	}

	private native android.app.Dialog n_onCreateDialog (int p0, android.os.Bundle p1);


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();


	public void onNewIntent (android.content.Intent p0)
	{
		n_onNewIntent (p0);
	}

	private native void n_onNewIntent (android.content.Intent p0);


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


	public void onPostCreate (android.os.Bundle p0)
	{
		n_onPostCreate (p0);
	}

	private native void n_onPostCreate (android.os.Bundle p0);


	public void onPostResume ()
	{
		n_onPostResume ();
	}

	private native void n_onPostResume ();


	public void onPrepareDialog (int p0, android.app.Dialog p1)
	{
		n_onPrepareDialog (p0, p1);
	}

	private native void n_onPrepareDialog (int p0, android.app.Dialog p1);


	public void onPrepareDialog (int p0, android.app.Dialog p1, android.os.Bundle p2)
	{
		n_onPrepareDialog (p0, p1, p2);
	}

	private native void n_onPrepareDialog (int p0, android.app.Dialog p1, android.os.Bundle p2);


	public boolean onPrepareOptionsPanel (android.view.View p0, android.view.Menu p1)
	{
		return n_onPrepareOptionsPanel (p0, p1);
	}

	private native boolean n_onPrepareOptionsPanel (android.view.View p0, android.view.Menu p1);


	public void onRestart ()
	{
		n_onRestart ();
	}

	private native void n_onRestart ();


	public void onRestoreInstanceState (android.os.Bundle p0)
	{
		n_onRestoreInstanceState (p0);
	}

	private native void n_onRestoreInstanceState (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onResumeFragments ()
	{
		n_onResumeFragments ();
	}

	private native void n_onResumeFragments ();


	public void onSaveInstanceState (android.os.Bundle p0)
	{
		n_onSaveInstanceState (p0);
	}

	private native void n_onSaveInstanceState (android.os.Bundle p0);


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();


	public void onStop ()
	{
		n_onStop ();
	}

	private native void n_onStop ();


	public void onTitleChanged (java.lang.CharSequence p0, int p1)
	{
		n_onTitleChanged (p0, p1);
	}

	private native void n_onTitleChanged (java.lang.CharSequence p0, int p1);


	public void onUserLeaveHint ()
	{
		n_onUserLeaveHint ();
	}

	private native void n_onUserLeaveHint ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
