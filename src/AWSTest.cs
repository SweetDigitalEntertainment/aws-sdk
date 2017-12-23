using System;
using System.Collections;
using System.Collections.Generic;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Lambda.Model;
using Amazon.Runtime;
using Sweet.Unity.Amazon;
using UnityEngine;

public class AWSTest : MonoBehaviour
{
    public string UserPoolId = "eu-west-2_Y5Oh1WmdI";
    public string IdentityPoolId;
    public string Region = "eu-west-2";
    public string ClientId = "p0bctclvrjrdlfvp6ddj1fjs5";
    private AWSSDK _aws;
    private IAmazonCognitoIdentityProvider _cipClient;
    private CognitoUserPool _pool;
    private CognitoUser _user;

    void Start()
    {
        _aws = gameObject.AddComponent<AWSSDK>();
        _cipClient = _aws.CreateCognitoIdentityProviderClient(
            _aws.CreateAnonymousAWSCredentials(),
            Region);
        _pool = new CognitoUserPool(UserPoolId, ClientId, _cipClient);
        _user = new CognitoUser("wuddupbuddddy", ClientId, _pool, _cipClient);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetCredentials();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SignUp();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Login();
        }
    }


    public void GetCredentials()
    {
        Debug.Log("DOING: GetCredentials");

        var credentials = _aws.CreateCognitoAWSCredentials(IdentityPoolId, Region);


        DateTime startTime = DateTime.Now;
        credentials.GetCredentialsAsync(r =>
            {
                if (r.Exception != null)
                {
                    Debug.LogException(r.Exception);
                    return;
                }

                Debug.Log("SUCCESS: GetCredentials: " + (DateTime.Now - startTime).TotalSeconds);

                startTime = DateTime.Now;
                Debug.Log("DOING: GetCredentials AGAIN!!!");
                credentials.GetCredentialsAsync(newR =>
                {

                    if (newR.Exception != null)
                    {
                        Debug.LogException(newR.Exception);
                        return;
                    }

                    Debug.Log("SUCCESS: GetCredentials: " + (DateTime.Now - startTime).TotalSeconds);
                    startTime = DateTime.Now;
                    Debug.Log("DOING: GetCredentials LAST TIME!!!");
                    ImmutableCredentials c = credentials.GetCredentials();
                    Debug.Log("SUCCESS: GetCredentials: " + (DateTime.Now - startTime).TotalSeconds);

                });
            });
    }

    public void SignUp()
    {
        Debug.Log("DOING: SignUp");
        var request = new SignUpRequest();
        request.Username = "wuddupbuddddy";
        request.Password = "aBc&0aBc&0aBc&0aBc&0aBc&0aBc&0";
        request.ClientId = ClientId;

        _cipClient.SignUpAsync(request, r =>
        {
            if (r.Exception != null)
            {
                Debug.LogException(r.Exception);
                return;
            }

            Debug.Log("SUCCESS: SignUp");
            Debug.Log("UserConfirmed: " + r.Response.UserConfirmed);
            Debug.Log("UserSub: " + r.Response.UserSub);
        });
    }

    public void Login()
    {
        Debug.Log("DOING: Login");

        _user.StartWithSrpAuthAsync(new InitiateSrpAuthRequest()
        {
            Password = "aBc&0aBc&0aBc&0aBc&0aBc&0aBc&0"
        }, r =>
        {
            if (r.Exception != null)
            {
                Debug.LogException(r.Exception);
                return;
            }

            if (r.Result.AuthenticationResult != null)
            {
                Debug.Log("r.Result.AuthenticationResult.AccessToken: " + r.Result.AuthenticationResult.AccessToken);
                Debug.Log("r.Result.AuthenticationResult.IdToken: " + r.Result.AuthenticationResult.IdToken);
                Debug.Log("r.Result.AuthenticationResult.TokenType: " + r.Result.AuthenticationResult.TokenType);

                ICognitoAWSCredentials credentials = _user.GetCognitoAWSCredentials(IdentityPoolId, RegionEndpoint.GetBySystemName(Region), _aws);

                credentials.GetCredentialsAsync(creds =>
                {
                    if (creds.Exception != null)
                    {
                        Debug.LogException(creds.Exception);
                        return;
                    }

                    Debug.Log("creds.Response.AccessKey: " + creds.Response.AccessKey);
                    Debug.Log("creds.Response.SecretKey: " + creds.Response.SecretKey);
                    Debug.Log("creds.Response.Token: " + creds.Response.Token);
                });
            }
            else
            {
                Debug.Log("r.Result.ChallengeName: " + r.Result.ChallengeName);
            }
        });
    }
}
