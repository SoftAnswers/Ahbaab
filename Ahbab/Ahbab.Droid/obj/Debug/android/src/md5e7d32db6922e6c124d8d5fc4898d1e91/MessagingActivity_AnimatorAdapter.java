package md5e7d32db6922e6c124d8d5fc4898d1e91;


public class MessagingActivity_AnimatorAdapter
	extends android.animation.AnimatorListenerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationEnd:(Landroid/animation/Animator;)V:GetOnAnimationEnd_Landroid_animation_Animator_Handler\n" +
			"";
		mono.android.Runtime.register ("Asawer.Droid.MessagingActivity+AnimatorAdapter, Asawer.Droid", MessagingActivity_AnimatorAdapter.class, __md_methods);
	}


	public MessagingActivity_AnimatorAdapter ()
	{
		super ();
		if (getClass () == MessagingActivity_AnimatorAdapter.class)
			mono.android.TypeManager.Activate ("Asawer.Droid.MessagingActivity+AnimatorAdapter, Asawer.Droid", "", this, new java.lang.Object[] {  });
	}

	public MessagingActivity_AnimatorAdapter (android.view.View p0, android.app.Activity p1)
	{
		super ();
		if (getClass () == MessagingActivity_AnimatorAdapter.class)
			mono.android.TypeManager.Activate ("Asawer.Droid.MessagingActivity+AnimatorAdapter, Asawer.Droid", "Android.Views.View, Mono.Android:Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public void onAnimationEnd (android.animation.Animator p0)
	{
		n_onAnimationEnd (p0);
	}

	private native void n_onAnimationEnd (android.animation.Animator p0);

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
