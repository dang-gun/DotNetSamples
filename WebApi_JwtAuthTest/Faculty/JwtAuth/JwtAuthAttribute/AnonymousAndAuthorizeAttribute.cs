using JwtAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace DGAuthServer;

/// <summary>
/// �͸��� ����ϰ� ���������� �������� �������� ��ȿ�� �˻縦 �Ѵ�.
/// </summary>
/// <remarks>�� �Ӽ��� ����ϸ� ���������� �������� AllowAnonymousAttribute����
/// ���������� �������� AuthorizeAttributeó�� �۵��Ѵ�.<br />
/// ������ �� �Ӽ� ��ü�� ���÷��� ��ūó���� ���� �����Ƿ�
/// ���÷��� ��ū�� �ִ� ��������ū�� ���� ��Ȳ�� ó������ ���Ѵ�.
/// </remarks>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AnonymousAndAuthorizeAttribute : Attribute, IAuthorizationFilter
{
	public void OnAuthorization(AuthorizationFilterContext context)
	{

        bool bAllowAnonymous
            = context.ActionDescriptor
                    .EndpointMetadata
                    .OfType<AllowAnonymousAttribute>().Any();
        if (true == bAllowAnonymous)
        {//AllowAnonymous���� �����Ǿ� �ִ�.

            //������ ��ŵ�Ѵ�.
            return;
        }

        //�������� Ȯ��
        long nUser = 0;
        foreach (Claim item in context.HttpContext.User.Claims.ToArray())
        {
            if (item.Type == "idUser")
            {//���� ������ �ִ�.
                nUser = Convert.ToInt64(item.Value);
                break;
            }
        }

        //1�̻��϶��� �������� ��ū�� ���� ���̴�.
        //�� �Ӽ��� -1(�͸�ó��)�϶��� �͸�ó���� ����Ѵ�.
        if (0 == nUser)
        {//���������� �߸��Ǿ���.

            //���������� �ִµ� �߸��Ǿ���.
            //401����
            context.Result
                = new JsonResult(new { message = "Unauthorized" })
                { StatusCode = StatusCodes.Status401Unauthorized };
        }

    }
}