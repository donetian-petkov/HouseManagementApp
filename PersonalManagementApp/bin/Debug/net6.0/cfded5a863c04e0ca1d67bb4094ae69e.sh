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

ps 10917;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 10917 > /dev/null;
done;

for child in $(list_child_processes 10923);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/donetianpetkov/Documents/GitHub/PersonalManagementApp/PersonalManagementApp/bin/Debug/net6.0/cfded5a863c04e0ca1d67bb4094ae69e.sh;
