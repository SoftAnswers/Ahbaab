package md5eb0cf08da40b997b67417d22a0f070c8;


public class IInAppBillingServiceStub_Proxy
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.os.IInterface
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_asBinder:()Landroid/os/IBinder;:GetAsBinderHandler:Android.OS.IInterfaceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Com.Android.Vending.Billing.IInAppBillingServiceStub+Proxy, Plugin.InAppBilling.VendingLibrary, Version=1.2.4.0, Culture=neutral, PublicKeyToken=null", IInAppBillingServiceStub_Proxy.class, __md_methods);
	}


	public IInAppBillingServiceStub_Proxy ()
	{
		super ();
		if (getClass () == IInAppBillingServiceStub_Proxy.class)
			mono.android.TypeManager.Activate ("Com.Android.Vending.Billing.IInAppBillingServiceStub+Proxy, Plugin.InAppBilling.VendingLibrary, Version=1.2.4.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public IInAppBillingServiceStub_Proxy (android.os.IBinder p0)
	{
		super ();
		if (getClass () == IInAppBillingServiceStub_Proxy.class)
			mono.android.TypeManager.Activate ("Com.Android.Vending.Billing.IInAppBillingServiceStub+Proxy, Plugin.InAppBilling.VendingLibrary, Version=1.2.4.0, Culture=neutral, PublicKeyToken=null", "Android.OS.IBinder, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public android.os.IBinder asBinder ()
	{
		return n_asBinder ();
	}

	private native android.os.IBinder n_asBinder ();

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