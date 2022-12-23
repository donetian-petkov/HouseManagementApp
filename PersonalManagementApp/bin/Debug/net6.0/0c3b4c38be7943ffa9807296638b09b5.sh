function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 80222;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 80222 > /dev/null;
done;

for child in $(list_child_processes 80225);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/donetianpetkov/Documents/GitHub/HouseManagementApp/PersonalManagementApp/bin/Debug/net6.0/0c3b4c38be7943ffa9807296638b09b5.sh;
