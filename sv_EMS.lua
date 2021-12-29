function respawnfunc(source, args, rawCommand)
	TriggerClientEvent('ems:forcerespawn', source)
end

RegisterCommand('respawn', respawnfunc, false)

function revivefunc(source, args, rawCommand)
	TriggerClientEvent('ems:revive', source)
end

RegisterCommand('revive', revivefunc, false)

function cprfunc(source, args, rawCommand)
	local numpumps = 30
	if (tablelength(args) > 0) then
		numpumps = tonumber(args[1])
	end
	TriggerClientEvent('ems:performcpr', source, numpumps)
end

RegisterCommand('cpr', cprfunc, false)

function diefunc(source, args, rawCommand)
	TriggerClientEvent('ems:die', source)
end

RegisterCommand('die', diefunc, false)

function tablelength(T)
  local count = 0
  for _ in pairs(T) do count = count + 1 end
  return count
end