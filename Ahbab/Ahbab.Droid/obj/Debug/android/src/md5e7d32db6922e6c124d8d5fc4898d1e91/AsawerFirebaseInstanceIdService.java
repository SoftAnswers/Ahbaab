package md5e7d32db6922e6c124d8d5fc4898d1e91;


public class AsawerFirebaseInstanceIdService
	extends com.google.firebase.iid.FirebaseInstanceIdService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("Asawer.Droid.AsawerFirebaseInstanceIdService, Asawer.Droid", AsawerFirebaseInstanceIdService.class, __md_methods);
	}


	public AsawerFirebaseInstanceIdService ()
	{
		super ();
		if (getClass () == AsawerFirebaseInstanceIdService.class)
			mono.android.TypeManager.Activate ("Asawer.Droid.AsawerFirebaseInstanceIdService, Asawer.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

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
