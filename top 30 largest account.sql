use PlatformOneLive 
go

declare @AsAtD8 as datetime
DECLARE @AsAtD8_Txn as datetime

/*Hard coded values*/
SET @AsAtD8 = '2023-10-27' --change this
SET @AsAtD8_Txn = '2023-10-27' --change this, this is the last transaction date for imperial 

/*Seventh Result SET*/
	--30 Largest Accounts by value
	select top 30 P1AccountCode, al.AccountName,
	CASE WHEN client.FirstName = 'Platform One' AND client.Surname = 'Platform One' THEN client.Surname ELSE
	client.Surname + ', ' + client.FirstName END as 'Client Name', 
	TotAccValue, c.Name AS 'Adviser Name', tc.Description AS 'Adviser Firm', @AsAtD8 As AsAtDate 
	from (select P1AccountId, sum(CurrValue) as TotAccValue 
		  from (select * 
				from (select b.P1AccountId, b.WrapperId, b.CashAccountSummaryId as SummId, 
							 c.TypePortfolioId, round(a.Value * pfo.ExRate(@AsAtd8, b.CurrISOCode ,'GBP'),2) as CurrValue 
					  from (select xx.CashBalanceId, xx.CashAccountSummaryId, @AsAtD8 as AsAtDate, xx.value
                            from pfo.CashBalance as xx inner join
                                 (select cashaccountsummaryid, MAX(AsAtDate) as asatdate 
                                  from pfo.CashBalance 
                                  where AsAtDate <= @ASAtD8 
                                  group by cashaccountsummaryid) as yy on xx.CashAccountSummaryId = yy.CashAccountSummaryId and xx.AsAtDate = yy.asatdate inner join
                                 (
									select cas.CashAccountSummaryID--, cas.P1AccountId--, acc.P1AccountCode
									from pfo.CashAccountSummary as cas
										inner join 
										(
											select cashaccountsummaryid,
											MAX(AsAtDate) as datereceived 
											from pfo.CashBalance
											where AsAtDate <= @AsAtD8 
											group by CashAccountSummaryId
										) ct
										on ct.cashaccountsummaryid = cas.CashAccountSummaryID
										--debug
										inner join [pfo].[P1Accounts] acc
											on cas.P1AccountId = acc.P1AccountId
										inner join
											(
			
												Select a.P1AccountId, typeportfolioid, Logontoken
												FROM [PlatformOneLive].[pfo].[AscentricLogon] a 
												INNER JOIN 
													(
													select P1AccountId, MAX(AscentricLogonId) as AscentricLogonId
													FROM [PlatformOneLive].[pfo].[AscentricLogon]
													--WHERE P1AccountId IS NOT NULL
													WHERE TypePortfolioId = 13
													Group by P1AccountId
													) b
													on a.P1AccountId = b.P1AccountId
													and a.AscentricLogonId = b.AscentricLogonId
											) as al 
											on acc.P1AccountCode = al.LogonToken
										UNION ALL
										select cas.CashAccountSummaryID--, cas.P1AccountId--, acc.P1AccountCode
										from pfo.CashAccountSummary as cas
										inner join 
										(
											select cashaccountsummaryid,
											MAX(DateReceived) as datereceived 
											from pfo.CashTxn
											where DateReceived <= @AsAtD8 
											group by CashAccountSummaryId
										) ct
										on ct.cashaccountsummaryid = cas.CashAccountSummaryID
										--debug
										inner join [pfo].[P1Accounts] acc
											on cas.P1AccountId = acc.P1AccountId
										inner join
											(
			
												Select a.P1AccountId, typeportfolioid, Logontoken
												FROM [PlatformOneLive].[pfo].[AscentricLogon] a 
												INNER JOIN 
													(
													select P1AccountId, MAX(AscentricLogonId) as AscentricLogonId
													FROM [PlatformOneLive].[pfo].[AscentricLogon]
													--WHERE P1AccountId IS NOT NULL
													WHERE TypePortfolioId <> 13
													Group by P1AccountId
													) b
													on a.P1AccountId = b.P1AccountId
													and a.AscentricLogonId = b.AscentricLogonId
											) as al 
											on acc.P1AccountCode = al.LogonToken
								  
								  )as zz on xx.CashAccountSummaryId = zz.CashAccountSummaryId 
                            where xx.asatdate <= @AsAtD8 AND xx.value <> 0) as a inner join 
							-- and zz.datereceived <= xx.asatdate
						   pfo.CashAccountSummary as b on a.CashAccountSummaryId = b.CashAccountSummaryId inner join 
						   pfo.AscentricLogon as c on b.P1AccountId = c.P1AccountId 
					  where a.AsAtDate = @AsAtD8
					 ) as x 
				group by P1AccountId, WrapperId, SummId, TypePortfolioId, CurrValue
				union all
				select * 
				from (select b.P1AccountId, b.WrapperId, b.NCASummaryId as SummId, c.TypePortfolioId, 
							 round(a.CurrValue * pfo.ExRate(@AsAtd8, b.CurrISOCode ,'GBP'),2) as CurrValue 
					  from (select xx.ncaBalanceId, xx.ncaSummaryId, @AsAtD8 as ValuationDate, xx.currvalue
                            from pfo.NCABalance as xx inner join
                                 (select ncasummaryid, MAX(valuationDate) as valuationdate 
                                  from pfo.ncaBalance 
                                  where valuationDate <= @ASAtD8 
                                  group by ncasummaryid) as yy on xx.ncaSummaryId = yy.ncaSummaryId and xx.ValuationDate = yy.valuationdate left join
                                 (select ncasummaryid, MAX(datereceived) as datereceived 
                                  from pfo.ncaTxn where DateReceived <= @AsAtD8 
                                  group by ncaSummaryId) as zz on xx.ncaSummaryId = zz.ncaSummaryId 
                            where xx.valuationdate <= @AsAtD8 AND xx.currvalue <> 0 and (zz.datereceived <= xx.valuationdate or zz.datereceived is null)) as a inner join 
						   pfo.NcaSummary as b on a.NCASummaryId = b.NCASummaryId inner join 
						   pfo.AscentricLogon as c on b.P1AccountId = c.P1AccountId 
					  where a.ValuationDate = @AsAtD8
					 ) as x 
				group by P1AccountId, WrapperId, SummId, TypePortfolioId, CurrValue 
				union all
				select * 
				from (select b.P1AccountId, b.WrapperId, b.SecuritiesSummaryId as SummId, c.TypePortfolioId, 
							 round(a.CurrValue * pfo.ExRate(@AsAtd8, b.CurrISOCode ,'GBP'),2) as CurrValue 
					  from (select xx.SecuritiesBalanceId, xx.SecuritiesSummaryId, @AsAtD8 as AsAtDate, xx.Currvalue
                            from pfo.SecuritiesBalance as xx inner join
                                 (select Securitiessummaryid, MAX(asAtDate) as asatdate 
                                  from pfo.SecuritiesBalance 
                                  where AsAtDate <= @ASAtD8 
                                  group by Securitiessummaryid) as yy on xx.SecuritiesSummaryId = yy.SecuritiesSummaryId and xx.AsAtDate = yy.asatdate inner join
                                 (
									select cas.SecuritiesSummaryId--, cas.P1AccountId--, acc.P1AccountCode
									from pfo.SecuritiesSummary as cas
										inner join 
										(
											select SecuritiesSummaryId,
											MAX(AsAtDate) as datereceived 
											from pfo.SecuritiesBalance 
											where AsAtDate <= @AsAtD8 
											group by SecuritiesSummaryId
										) ct
										on ct.SecuritiesSummaryId = cas.SecuritiesSummaryId
										--debug
										inner join [pfo].[P1Accounts] acc
											on cas.P1AccountId = acc.P1AccountId
										inner join
											(
			
												Select a.P1AccountId, typeportfolioid, Logontoken
												FROM [PlatformOneLive].[pfo].[AscentricLogon] a 
												INNER JOIN 
													(
													select P1AccountId, MAX(AscentricLogonId) as AscentricLogonId
													FROM [PlatformOneLive].[pfo].[AscentricLogon]
													--WHERE P1AccountId IS NOT NULL
													WHERE TypePortfolioId = 13
													Group by P1AccountId
													) b
													on a.P1AccountId = b.P1AccountId
													and a.AscentricLogonId = b.AscentricLogonId
											) as al 
											on acc.P1AccountCode = al.LogonToken
											--on cas.P1AccountId = al.P1AccountId
									UNION ALL
									select cas.SecuritiesSummaryId--, cas.P1AccountId--, acc.P1AccountCode
									from pfo.SecuritiesSummary as cas
										inner join 
										(
											select SecuritiesSummaryId,
											MAX(DateReceived) as datereceived 
											from pfo.SecuritiesTxn 
											where DateReceived <= @AsAtD8_Txn 
											group by SecuritiesSummaryId
										) ct
										on ct.SecuritiesSummaryId = cas.SecuritiesSummaryId
										--debug
										inner join [pfo].[P1Accounts] acc
											on cas.P1AccountId = acc.P1AccountId
										inner join
											(
			
												Select a.P1AccountId, typeportfolioid, Logontoken
												FROM [PlatformOneLive].[pfo].[AscentricLogon] a 
												INNER JOIN 
													(
													select P1AccountId, MAX(AscentricLogonId) as AscentricLogonId
													FROM [PlatformOneLive].[pfo].[AscentricLogon]
													--WHERE P1AccountId IS NOT NULL
													WHERE TypePortfolioId <> 13
													Group by P1AccountId
													) b
													on a.P1AccountId = b.P1AccountId
													and a.AscentricLogonId = b.AscentricLogonId
											) as al 
											on acc.P1AccountCode = al.LogonToken
								 ) as zz on xx.SecuritiesSummaryId = zz.SecuritiesSummaryId 
                            where xx.asatdate <= @AsAtD8 AND xx.currvalue <> 0) as a inner join 
							-- and zz.datereceived <= xx.asatdate
						   pfo.SecuritiesSummary as b on a.SecuritiesSummaryId = b.SecuritiesSummaryId inner join 
						   pfo.AscentricLogon as c on b.P1AccountId = c.P1AccountId 
					  where a.AsAtDate = @AsAtD8
					 ) as x 
				group by P1AccountId, WrapperId, SummId, TypePortfolioId, CurrValue
			   ) as assets
		  group by P1AccountId
		 ) as a left join pfo.P1Accounts on a.P1AccountId = pfo.p1accounts.P1AccountId 
	LEFT JOIN (SELECT P1AccountId, aspnet_Users_UserId, AccountName, AscentricLogonId, LogonToken FROM pfo.AscentricLogon WHERE P1AccountId IS NOT NULL) AS al ON P1AccountCode = al.LogonToken 
	LEFT JOIN pfo.AscentricLogonCompany alc on alc.AscentricLogonId = al.AscentricLogonId
	INNER JOIN (SELECT CompanyId, Name, TypeCompanyId FROM pfo.Company) AS c on c.CompanyId = alc.Companyid
	INNER JOIN (SELECT TypeCompanyId, Description FROM pfo.TypeCompany) AS tc on tc.TypeCompanyId = c.TypeCompanyId AND tc.TypeCompanyId NOT IN(1)
	INNER JOIN (SELECT aspnet_Users_Userid, FirstName, Surname FROM pfo.PfoUser) AS client ON client.aspnet_Users_UserId = al.aspnet_users_userid

	order by TotAccValue desc
