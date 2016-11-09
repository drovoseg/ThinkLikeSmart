
using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Tls.ThinkLikeSmart.Common.Presenters.Authentication;
using Tls.ThinkLikeSmart.Common.Views.Authentication;
using Tls.ThinkLikeSmart.Droid.Storage;
using Android.Views;
using Tls.ThinkLikeSmart.Common.Factories;

namespace Tls.ThinkLikeSmart.Droid.Activities.Authentication
{
    [Activity]
    public class LoginActivity : Activity, ILoginView
    {

        private Button loginButton;
        private Button registerButton;
        private EditText accountNameEditText;
        private EditText passwordEditText;
        private RelativeLayout rememberDialogLayout;
        private ToggleButton rememberPasswordToggleButton;
        private TextView countryNameTextView;
        private TextView countryPnoneCodeTextView;
        private RelativeLayout countryLayout;
        private RadioGroup loginTypeRadioGroup;
        private TextView forgetPasswordTextView;

        private readonly LoginPresenter presenter;

        //    public static Context mContext;
        //    private boolean isRegFilter = false;
        //    public static final int ANIMATION_END = 2;
        //    public static final int ACCOUNT_NO_EXIST = 3;
        //    private String mInputName, mInputPwd;
        //    private boolean isDialogCanel = false;
        //    NormalDialog dialog;
        //    int current_type;
        //    boolean isApEnter;
        //    NormalDialog dialog_enter_ap;
        //    boolean isExitAp;

        #region ILoginView properties implementations

        public bool CountryContainerVisible
        {
            get
            {
                return countryLayout.Visibility == ViewStates.Visible;
            }
            set
            {
                countryLayout.Visibility = value ? ViewStates.Visible : ViewStates.Gone;
            }
        }

        public string AccountName
        {
            get { return accountNameEditText.Text; }
            set { accountNameEditText.Text = value; }
        }

        public string Password
        {
            get { return passwordEditText.Text; }
            set { passwordEditText.Text = value; }
        }

        public bool RememberPasswordToggled
        {
            get { return rememberPasswordToggleButton.Checked; }
            set { rememberPasswordToggleButton.Checked = value; }
        }

        public string CountryPhoneCode
        {
            get { return countryPnoneCodeTextView.Text; }
            set { countryPnoneCodeTextView.Text = value; }
        }

        public string CountryName
        {
            get { return countryNameTextView.Text; }
            set { countryNameTextView.Text = value; }
        }

        #endregion

        #region lifecycle

        public LoginActivity()
        {
            presenter = new LoginPresenter(this, new StrategiesFactory(), new AndroidSettings(), new AndroidResourcesProvider());
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

    //        mContext = this;
    //        isExitAp = getIntent().getBooleanExtra("isExitAp", false);
            InitComponents();

            presenter.ViewCreated();

        }

        public void InitComponents()
        {
            loginButton = (Button)FindViewById(Resource.Id.login);

            registerButton = (Button)FindViewById(Resource.Id.register);
            
            accountNameEditText = FindViewById<EditText>(Resource.Id.account_name);
            passwordEditText = FindViewById<EditText>(Resource.Id.password);
            rememberDialogLayout = FindViewById<RelativeLayout>(Resource.Id.dialog_remember);
            rememberPasswordToggleButton = FindViewById<ToggleButton>(Resource.Id.remember_password_button);
            countryNameTextView = FindViewById<TextView>(Resource.Id.name);
            countryPnoneCodeTextView = FindViewById<TextView>(Resource.Id.count);
            countryLayout = FindViewById<RelativeLayout>(Resource.Id.country_layout);

            loginTypeRadioGroup = FindViewById<RadioGroup>(Resource.Id.layout_login_type);
            RadioButton phoneRadioButton = FindViewById<RadioButton>(Resource.Id.type_phone);
            RadioButton emailRadioButton = FindViewById<RadioButton>(Resource.Id.type_email);

            forgetPasswordTextView = (TextView)FindViewById(Resource.Id.forget_pwd);
            //tv_Anonymous_login = (TextView)FindViewById(Resource.Id.tv_Anonymous_login);

            phoneRadioButton.Click += OnPhoneRadioButtonClick;
            emailRadioButton.Click += OnEmailRadioButtonClick;

            forgetPasswordTextView.Click += OnForgetPasswordButtonClick;
            countryLayout.Click += OnCountryLayoutClick;
            loginButton.Click += OnLoginButtonClick;
            registerButton.Click += OnRegisterButtonClick;
            rememberPasswordToggleButton.Click += OnRememberPasswordToggleButtonClick;
            //tv_Anonymous_login.setOnClickListener(this);
            //isApEnter = SharedPreferencesManager.getInstance().getIsApEnter(
            //        mContext);
            //if (isApEnter)
            //{
            //    Intent i = new Intent(mContext, MainActivity.class);

            //    startActivity(i);
            //} else {
            //    showApDialog();
            //}
        }

        #endregion

        #region GUI event handlers

        private void OnRememberPasswordToggleButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnRegisterButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnLoginButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCountryLayoutClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnEmailRadioButtonClick(object sender, EventArgs e)
        {
            presenter.HandleEmailRadioButtonClick();
        }

        private void OnPhoneRadioButtonClick(object sender, EventArgs e)
        {
            presenter.HandlePhoneRadioButtonClick();
        }

        private void OnForgetPasswordButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILoginView mehtod implementations

        public void TogglePhoneLoginType()
        {
            loginTypeRadioGroup.Check(Resource.Id.type_phone);
        }

        public void ToggleEmailLoginType()
        {
            loginTypeRadioGroup.Check(Resource.Id.type_email);
        }

        public void SetAccountNamePhoneHint()
        {
        }

        public void SetAccountNameEmailHint()
        {
        }

        #endregion

        //public void regFilter()
        //{
        //    IntentFilter filter = new IntentFilter();
        //    filter.addAction(Constants.Action.REPLACE_EMAIL_LOGIN);
        //    filter.addAction(Constants.Action.REPLACE_PHONE_LOGIN);
        //    filter.addAction(Constants.Action.ACTION_COUNTRY_CHOOSE);
        //    mContext.registerReceiver(mReceiver, filter);
        //    isRegFilter = true;
        //}

        //private BroadcastReceiver mReceiver = new BroadcastReceiver() {

        //        @Override

        //        public void onReceive(Context arg0, Intent intent)
        //{
        //    if (intent.getAction().equals(Constants.Action.REPLACE_EMAIL_LOGIN))
        //    {
        //        type_email.setChecked(true);
        //        type_phone.setChecked(false);
        //        choose_country.setVisibility(RelativeLayout.GONE);
        //        mAccountName.setText(intent.getStringExtra("username"));
        //        mAccountPwd.setText(intent.getStringExtra("password"));
        //        current_type = Constants.LoginType.EMAIL;
        //        login();
        //    }
        //    else if (intent.getAction().equals(
        //          Constants.Action.REPLACE_PHONE_LOGIN))
        //    {
        //        type_email.setChecked(false);
        //        type_phone.setChecked(true);
        //        choose_country.setVisibility(RelativeLayout.VISIBLE);
        //        mAccountName.setText(intent.getStringExtra("username"));
        //        mAccountPwd.setText(intent.getStringExtra("password"));
        //        default_count.setText("+" + intent.getStringExtra("code"));
        //        current_type = Constants.LoginType.PHONE;
        //        login();
        //    }
        //    else if (intent.getAction().equals(
        //          Constants.Action.ACTION_COUNTRY_CHOOSE))
        //    {
        //        String[] info = intent.getStringArrayExtra("info");
        //        default_name.setText(info[0]);
        //        default_count.setText("+" + info[1]);
        //    }
        //}
        //	};

        //	@Override
        //    public void onClick(View v)
        //{
        //    // TODO Auto-generated method stub
        //    switch (v.getId())
        //    {
        //        case Resource.Id.forgetPasswordButton:
        //            Uri uri = Uri.parse(Constants.FORGET_PASSWORD_URL);
        //            Intent open_web = new Intent(Intent.ACTION_VIEW, uri);
        //            startActivity(open_web);
        //            break;
        //        case Resource.Id.country_layout:
        //            Intent i = new Intent(mContext, SearchListActivity.class);

        //            startActivity(i);
        //			break;
        //		case Resource.Id.type_phone:
        //			type_phone.setChecked(true);
        //			type_email.setChecked(false);
        //			choose_country.setVisibility(RelativeLayout.VISIBLE);
        //			current_type = Constants.LoginType.PHONE;

        //            initRememberPass();
        //			break;
        //		case Resource.Id.type_email:
        //			type_phone.setChecked(false);
        //			type_email.setChecked(true);
        //			choose_country.setVisibility(RelativeLayout.GONE);
        //			current_type = Constants.LoginType.EMAIL;

        //            initRememberPass();
        //			break;
        //		case Resource.Id.login:

        //            login();
        //			break;
        //		case Resource.Id.register:
        //			Intent register = new Intent(mContext,
        //                    AltogetherRegisterActivity.class);

        //            startActivity(register);
        //			break;
        //		case Resource.Id.remember_pass:
        //			boolean isChecked = false;
        //			if (current_type == Constants.LoginType.PHONE) {
        //				isChecked = SharedPreferencesManager.getInstance()
        //						.getIsRememberPass(mContext);
        //			} else {
        //				isChecked = SharedPreferencesManager.getInstance()
        //						.getIsRememberPass_email(mContext);
        //			}

        //			if (isChecked) {
        //				TextView dialog_text = (TextView)dialog_remember
        //                        .FindViewById(Resource.Id.dialog_text);
        //ImageView dialog_img = (ImageView)dialog_remember
        //        .FindViewById(Resource.Id.dialog_img);
        //dialog_img.setImageResource(R.drawable.ic_unremember_pwd);
        //				dialog_text.setText(R.string.un_rem_pass);
        //				dialog_text.setGravity(Gravity.CENTER);
        //				dialog_remember.setVisibility(RelativeLayout.VISIBLE);
        //				Animation anim = new ScaleAnimation(0.1f, 1.0f, 0.1f, 1f,
        //                        Animation.RELATIVE_TO_SELF, 0.5f,
        //                        Animation.RELATIVE_TO_SELF, 0.5f);
        //anim.setDuration(200);
        //				anim.setAnimationListener(new AnimationListener()
        //{

        //    @Override

        //                    public void onAnimationEnd(Animation arg0)
        //{
        //    // TODO Auto-generated method stub
        //    Message msg = new Message();
        //    msg.what = ANIMATION_END;
        //    mHandler.sendMessageDelayed(msg, 500);
        //}

        //@Override
        //                    public void onAnimationRepeat(Animation arg0)
        //{
        //    // TODO Auto-generated method stub

        //}

        //@Override
        //                    public void onAnimationStart(Animation arg0)
        //{
        //    // TODO Auto-generated method stub

        //}

        //				});
        //				dialog_remember.startAnimation(anim);

        //				if (current_type == Constants.LoginType.PHONE) {
        //					SharedPreferencesManager.getInstance().putIsRememberPass(
        //                            mContext, false);
        //				} else {
        //					SharedPreferencesManager.getInstance()
        //							.putIsRememberPass_email(mContext, false);
        //				}

        //				remember_pwd_img.setImageResource(R.drawable.ic_unremember_pwd);
        //			} else {
        //				TextView dialog_text = (TextView)dialog_remember
        //                        .FindViewById(Resource.Id.dialog_text);
        //ImageView dialog_img = (ImageView)dialog_remember
        //        .FindViewById(Resource.Id.dialog_img);
        //dialog_img.setImageResource(R.drawable.ic_remember_pwd);
        //				dialog_text.setText(R.string.rem_pass);
        //				dialog_text.setGravity(Gravity.CENTER);
        //				dialog_remember.setVisibility(RelativeLayout.VISIBLE);
        //				Animation anim = new ScaleAnimation(0.1f, 1.0f, 0.1f, 1f,
        //                        Animation.RELATIVE_TO_SELF, 0.5f,
        //                        Animation.RELATIVE_TO_SELF, 0.5f);
        //anim.setDuration(200);
        //				anim.setAnimationListener(new AnimationListener()
        //{

        //    @Override

        //                    public void onAnimationEnd(Animation arg0)
        //{
        //    // TODO Auto-generated method stub
        //    Message msg = new Message();
        //    msg.what = ANIMATION_END;
        //    mHandler.sendMessageDelayed(msg, 500);
        //}

        //@Override
        //                    public void onAnimationRepeat(Animation arg0)
        //{
        //    // TODO Auto-generated method stub

        //}

        //@Override
        //                    public void onAnimationStart(Animation arg0)
        //{
        //    // TODO Auto-generated method stub

        //}

        //				});
        //				dialog_remember.startAnimation(anim);
        //				if (current_type == Constants.LoginType.PHONE) {
        //					SharedPreferencesManager.getInstance().putIsRememberPass(
        //                            mContext, true);
        //				} else {
        //					SharedPreferencesManager.getInstance()
        //							.putIsRememberPass_email(mContext, true);
        //				}
        //				remember_pwd_img.setImageResource(R.drawable.ic_remember_pwd);

        //			}
        //			break;
        //		case Resource.Id.tv_Anonymous_login:
        //			Account account = AccountPersist.getInstance()
        //                    .getActiveAccountInfo(mContext);
        //			if (null == account) {
        //				account = new Account();
        //			}
        //			account.three_number = "517400";
        //			account.rCode1 = "0";
        //			account.rCode2 = "0";
        //			account.sessionId = "0";
        //			AccountPersist.getInstance().setActiveAccount(mContext, account);
        //NpcCommon.mThreeNum = AccountPersist.getInstance()
        //					.getActiveAccountInfo(mContext).three_number;
        //			Intent login = new Intent(mContext, MainActivity.class);

        //            startActivity(login);
        //			((LoginActivity) mContext).finish();
        //			break;
        //		}
        //	}

        //	private Handler mHandler = new Handler(new Callback() {
        //        @Override

        //        public boolean handleMessage(Message msg)
        //{
        //    switch (msg.what)
        //    {
        //        case ANIMATION_END:
        //            Animation anim_on = new ScaleAnimation(1.0f, 0.1f, 1.0f, 0.1f,
        //                    Animation.RELATIVE_TO_SELF, 0.5f,
        //                    Animation.RELATIVE_TO_SELF, 0.5f);
        //            anim_on.setDuration(300);
        //            dialog_remember.startAnimation(anim_on);
        //            dialog_remember.setVisibility(RelativeLayout.GONE);
        //            break;
        //        case ACCOUNT_NO_EXIST:
        //            T.showShort(mContext, R.string.account_no_exist);
        //            if (dialog != null)
        //            {
        //                dialog.dismiss();
        //                dialog = null;
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //    return false;
        //}
        //	});

        //	@Override
        //    public void onBackPressed()
        //{
        //    super.isGoExit(true);
        //    this.finish();
        //}

        //private void login()
        //{
        //    mInputName = mAccountName.getText().toString().trim();
        //    mInputPwd = mAccountPwd.getText().toString().trim();
        //    if ((mInputName != null && !mInputName.equals(""))
        //            && (mInputPwd != null && !mInputPwd.equals("")))
        //    {
        //        if (null != dialog && dialog.isShowing())
        //        {
        //            Log.e("my", "isShowing");
        //            return;
        //        }
        //        dialog = new NormalDialog(mContext);
        //        dialog.setOnCancelListener(new OnCancelListener() {

        //                @Override

        //                public void onCancel(DialogInterface arg0)
        //{
        //    // TODO Auto-generated method stub
        //    isDialogCanel = true;
        //}

        //			});
        //			dialog.setTitle(mContext.getResources().getString(
        //                    R.string.login_ing));
        //			dialog.showLoadingDialog();
        //			dialog.setCanceledOnTouchOutside(false);
        //			isDialogCanel = false;

        //			if (current_type == Constants.LoginType.PHONE) {
        //				String name = default_count.getText().toString() + "-"
        //                        + mInputName;
        //new LoginTask(name, mInputPwd).execute();
        //			} else {
        //				if (Utils.isNumeric(mInputName)) {
        //					if (mInputName.charAt(0) != '0') {
        //						mHandler.sendEmptyMessage(ACCOUNT_NO_EXIST);
        //						return;
        //					}
        //					new LoginTask(mInputName, mInputPwd).execute();
        //				} else {
        //					new LoginTask(mInputName, mInputPwd).execute();
        //				}
        //			}

        //		} else {
        //			if ((mInputName == null || mInputName.equals(""))
        //					&& (mInputPwd != null && !mInputPwd.equals(""))) {
        //				T.showShort(mContext, R.string.input_account);
        //			} else if ((mInputName != null && !mInputName.equals(""))
        //					&& (mInputPwd == null || mInputPwd.equals(""))) {
        //				T.showShort(mContext, R.string.input_password);
        //			} else {
        //				T.showShort(mContext, R.string.input_tip);
        //			}
        //		}
        //	}

        //	class LoginTask extends AsyncTask
        //{
        //    String username;
        //    String password;


        //        public LoginTask(String username, String password)
        //{
        //    this.username = username;
        //    this.password = password;
        //}

        //@Override
        //        protected Object doInBackground(Object... params)
        //{
        //    // TODO Auto-generated method stub
        //    Utils.sleepThread(1000);
        //    return NetManager.getInstance(mContext).login(username, password);
        //}

        //@Override
        //        protected void onPostExecute(Object object)
        //{
        //    // TODO Auto-generated method stub
        //    LoginResult result = NetManager
        //            .createLoginResult((JSONObject)object);
        //    switch (Integer.parseInt(result.error_code))
        //    {
        //        case NetManager.SESSION_ID_ERROR:
        //            Intent i = new Intent();
        //            i.setAction(Constants.Action.SESSION_ID_ERROR);
        //            MyApp.app.sendBroadcast(i);
        //            break;
        //        case NetManager.CONNECT_CHANGE:
        //            new LoginTask(username, password).execute();
        //            return;
        //        case NetManager.LOGIN_SUCCESS:
        //            if (isDialogCanel)
        //            {
        //                return;
        //            }
        //            if (null != dialog)
        //            {
        //                dialog.dismiss();
        //                dialog = null;
        //            }

        //            if (current_type == Constants.LoginType.PHONE)
        //            {
        //                SharedPreferencesManager.getInstance()
        //                        .putData(mContext,
        //                                SharedPreferencesManager.SP_FILE_GWELL,
        //                                SharedPreferencesManager.KEY_RECENTNAME,
        //                                mInputName);
        //                SharedPreferencesManager.getInstance().putData(mContext,
        //                        SharedPreferencesManager.SP_FILE_GWELL,
        //                        SharedPreferencesManager.KEY_RECENTPASS, mInputPwd);
        //                String code = default_count.getText().toString();
        //                code = code.substring(1, code.length());
        //                SharedPreferencesManager.getInstance().putData(mContext,
        //                        SharedPreferencesManager.SP_FILE_GWELL,
        //                        SharedPreferencesManager.KEY_RECENTCODE, code);
        //                SharedPreferencesManager.getInstance().putRecentLoginType(
        //                        mContext, Constants.LoginType.PHONE);
        //            }
        //            else
        //            {
        //                SharedPreferencesManager.getInstance().putData(mContext,
        //                        SharedPreferencesManager.SP_FILE_GWELL,
        //                        SharedPreferencesManager.KEY_RECENTNAME_EMAIL,
        //                        mInputName);
        //                SharedPreferencesManager.getInstance().putData(mContext,
        //                        SharedPreferencesManager.SP_FILE_GWELL,
        //                        SharedPreferencesManager.KEY_RECENTPASS_EMAIL,
        //                        mInputPwd);
        //                SharedPreferencesManager.getInstance().putRecentLoginType(
        //                        mContext, Constants.LoginType.EMAIL);
        //            }

        //            String codeStr1 = String.valueOf(Long.parseLong(result.rCode1));
        //            String codeStr2 = String.valueOf(Long.parseLong(result.rCode2));
        //            Account account = AccountPersist.getInstance()
        //                    .getActiveAccountInfo(mContext);
        //            if (null == account)
        //            {
        //                account = new Account();
        //            }
        //            account.three_number = result.contactId;
        //            account.phone = result.phone;
        //            account.email = result.email;
        //            account.sessionId = result.sessionId;
        //            account.rCode1 = codeStr1;
        //            account.rCode2 = codeStr2;
        //            account.countryCode = result.countryCode;
        //            AccountPersist.getInstance()
        //                    .setActiveAccount(mContext, account);
        //            NpcCommon.mThreeNum = AccountPersist.getInstance()
        //                    .getActiveAccountInfo(mContext).three_number;
        //            SharedPreferencesManager.getInstance().putIsApEnter(mContext,
        //                    false);
        //            Log.e("loginmode",
        //                    "login="
        //                            + SharedPreferencesManager.getInstance()
        //                                    .getIsApEnter(mContext));
        //            Intent login = new Intent(mContext, MainActivity.class);

        //                startActivity(login);
        //				((LoginActivity) mContext).finish();
        //				break;
        //			case NetManager.LOGIN_USER_UNEXIST:
        //				if (dialog != null) {
        //					dialog.dismiss();
        //					dialog = null;
        //				}
        //				if (!isDialogCanel) {
        //					T.showShort(mContext, R.string.account_no_exist);
        //				}
        //				break;
        //			case NetManager.LOGIN_PWD_ERROR:
        //				if (dialog != null) {
        //					dialog.dismiss();
        //					dialog = null;
        //				}
        //				if (!isDialogCanel) {
        //					T.showShort(mContext, R.string.password_error);
        //				}
        //				break;
        //			default:
        //				if (dialog != null) {
        //					dialog.dismiss();
        //					dialog = null;
        //				}
        //				if (!isDialogCanel) {
        //					T.showShort(mContext, R.string.loginfail);
        //				}
        //				break;
        //			}
        //		}

        //	}

        //	public void showApDialog()
        //{
        //    if (isExitAp)
        //    {
        //        return;
        //    }
        //    List<LocalDevice> aplist = APList.aplist;
        //    if (aplist.size() > 0)
        //    {
        //        if (dialog_enter_ap == null || !dialog_enter_ap.isShowing())
        //        {
        //            dialog_enter_ap = new NormalDialog(mContext, mContext
        //                    .getResources().getString(R.string.ap_device), mContext
        //                    .getResources().getString(R.string.ap_device_enter),
        //                    mContext.getResources().getString(R.string.ensure),
        //                    mContext.getResources().getString(R.string.cancel));
        //            dialog_enter_ap
        //                    .setOnButtonOkListener(new NormalDialog.OnButtonOkListener() {

        //                            @Override

        //                            public void onClick()
        //{
        //    // TODO Auto-generated method stub
        //    SharedPreferencesManager.getInstance()
        //            .putIsApEnter(mContext, true);
        //    NpcCommon.mThreeNum = "517400";
        //    Account account = AccountPersist.getInstance()
        //            .getActiveAccountInfo(mContext);
        //    if (null == account)
        //    {
        //        account = new Account();
        //    }
        //    account.three_number = "517400";
        //    account.rCode1 = "0";
        //    account.rCode2 = "0";
        //    account.sessionId = "0";
        //    AccountPersist.getInstance().setActiveAccount(
        //            mContext, account);
        //    NpcCommon.mThreeNum = AccountPersist
        //            .getInstance().getActiveAccountInfo(
        //                    mContext).three_number;
        //    Intent i = new Intent(mContext,
        //            MainActivity.class);

        //                                startActivity(i);
        //								((LoginActivity) mContext).finish();
        //							}
        //						});
        //				dialog_enter_ap
        //                        .setOnButtonCancelListener(new NormalDialog.OnButtonCancelListener() {

        //							@Override
        //                            public void onClick()
        //{
        //    // TODO Auto-generated method stub
        //    isExitAp = false;
        //    dialog_enter_ap.dismiss();
        //}
        //						});
        //				dialog_enter_ap.showNormalDialog();
        //				dialog_enter_ap.setCanceledOnTouchOutside(false);
        //			}

        //		}
        //	}

        //	@Override
        //    protected void onResume()
        //{
        //    // TODO Auto-generated method stub
        //    super.onResume();
        //    showApDialog();
        //}

        //@Override
        //    protected void onDestroy()
        //{
        //    // TODO Auto-generated method stub
        //    super.onDestroy();
        //    if (isRegFilter)
        //    {
        //        isRegFilter = false;
        //        mContext.unregisterReceiver(mReceiver);
        //    }
        //}

        //@Override
        //    public int getActivityInfo()
        //{
        //    // TODO Auto-generated method stub
        //    return Constants.ActivityInfo.ACTIVITY_LOGINACTIVITY;
        //}

        //}
    }
}

